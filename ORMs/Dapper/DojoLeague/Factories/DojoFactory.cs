using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;

namespace DojoLeague.Factory
{
    public class DojoFactory: IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory(){
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        //Specific DB queries below.
        public void Add(Dojo item) {
            string query = "INSERT INTO dojos (name, location, description) VALUES (@name, @location, @description)";
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojo> GetAll() {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public Dojo GetOne(int id) {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                using (var multi = dbConnection.QueryMultiple("SELECT * FROM dojos WHERE id=@id; SELECT * FROM ninjas WHERE dojos_id = @id;", new {id=id})) {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
    }

}