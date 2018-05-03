using System;
using System.Collections.Generic;
using DbConnection;

namespace crud
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,System.Action> commands = new Dictionary<string,System.Action> {
                {"read", Read},
                {"create", Create},
                {"delete", Delete},
                {"update", Update}
            };
            while(true){
                Console.WriteLine("Enter a command (read, create, delete, update) to interact with the database.");
                string command = Console.ReadLine();
                try {
                    commands[command]();
                } catch {
                    Console.WriteLine("Invalid command. Commands are read, create, delete, update.");
                }
            }
        }
        static void Read() {
            Console.WriteLine("==========INDEX==========");
            var result = DbConnector.Query("Select * from Users");
            for (int i = 0; i < result.Count; i++) {
                Console.WriteLine($"Result {i}:");
                foreach (var KeyValuePair in result[i]) {
                    Console.WriteLine($"{KeyValuePair.Key} : {KeyValuePair.Value}");
                }
                Console.WriteLine("=======================");
            }
        }
        static void Create() {
            //This is probably not secure, and there is no validation :)
            Console.WriteLine("==========CREATE============");
            Console.WriteLine("Enter first name:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string last = Console.ReadLine();
            Console.WriteLine("Enter favorite number:");
            //Let's assume the user enters a number for now.
            int favorite = Convert.ToInt32(Console.ReadLine());
            string queryString = $"INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ('{first}','{last}','{favorite}')";
            Console.WriteLine(queryString);
            DbConnector.Query(queryString);
            Read();
        }
        static void Delete() {
            Console.WriteLine("==========DELETE==========");
            Console.WriteLine("Select user id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            string queryString = $"DELETE FROM Users WHERE Id={id}";
            DbConnector.Query(queryString);
            Read();
        }
        static void Update() {
            Console.WriteLine("===========UPDATE============");
            bool valid = false;
            while (!valid) {
                Console.WriteLine("Search for User Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                string queryString = $"SELECT * FROM Users WHERE Id={id}";
                try {
                    var result = DbConnector.Query(queryString);
                    valid = true;
                    Console.WriteLine("=============================");
                    foreach (var KeyValuePair in result[0]) {
                        Console.WriteLine($"{KeyValuePair.Key} : {KeyValuePair.Value}");
                    }
                    Console.WriteLine("=============================");
                    Console.WriteLine("Update first name:");
                    string first = Console.ReadLine();
                    Console.WriteLine("Update last name:");
                    string last = Console.ReadLine();
                    Console.WriteLine("Update favorite number:");
                    int favorite = Convert.ToInt32(Console.ReadLine());
                    queryString = $"UPDATE Users SET FirstName='{first}', LastName='{last}', FavoriteNumber='{favorite}' WHERE Id={id}";
                    DbConnector.Query(queryString);
                    Read();
                }
                catch {
                    Console.WriteLine("User not found.");
                    valid = false;
                }
            }
        }
    }
}