using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;

namespace DojoLeague.Factory
{
    public class NinjaFactory: IFactory<Dojo>
    {
        private string connectionString;
        public NinjaFactory() {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Ninja item){
            using (IDbConnection dbConnection = Connection) {
                string query;
                if(item.dojos_id == null) {
                    query = "INSERT INTO ninjas (name, level, description) VALUES (@name, @level, @description)";
                } else {
                    query = "INSERT INTO ninjas (name, level, description, dojos_id) VALUES (@name, @level, @description, @dojos_id)";
                }
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public void BanishRecruit(int ninja_id, int dojo_id, bool recruit){
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                if(recruit){
                    dbConnection.Execute("UPDATE ninjas SET dojos_id = @dojo_id WHERE id=@ninja_id",new {ninja_id = ninja_id, dojo_id = dojo_id});
                } else {
                    dbConnection.Execute("UPDATE ninjas SET dojos_id = null WHERE id=@ninja_id", new {ninja_id = ninja_id});
                }
            }
        }
        public IEnumerable<Ninja> GetAll() {
            using (IDbConnection dbConnection = Connection) {
                string query = "SELECT * FROM ninjas LEFT JOIN dojos ON ninjas.dojos_id = dojos.id";
                dbConnection.Open();
                var ninjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => {ninja.dojo = dojo; return ninja;});
                return ninjas;
            }
        }
        public Ninja GetOne(int id){
            using (IDbConnection dbConnection = Connection) {
                var query = $"SELECT * FROM ninjas LEFT JOIN dojos ON ninjas.dojos_id=dojos.id WHERE ninjas.id = {id}";
                dbConnection.Open();    
                var myNinja = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; }).FirstOrDefault();
                return myNinja;
            }
        }
    }

}