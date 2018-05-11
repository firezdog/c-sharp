using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInWoods.Models;
 
namespace LostInWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        //Specific DB queries go here.
        public void Add(Trail item) {
            string query =  "INSERT INTO trails (trail_name, trail_description, trail_length, elevation_change, latitude, longitude) VALUES (@trail_name, @trail_description, @trail_length, @elevation_change, @latitude, @longitude)";
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll() {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT trail_name, trail_length, elevation_change, id FROM trails");
            }
        }
        public Trail FindOne(int id) {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id=@id", new {id = id}).FirstOrDefault();
            }
        }
    }
}
