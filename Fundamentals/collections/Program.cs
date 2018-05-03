using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            // (1) Hold integers from 0 to 9
            // (2) Names "Tim", "Martin", "Nikki", "Sara"
            // (3) Alternate between true and false for ten values
            // int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            // string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            // bool[] boolArray = new bool[10];
            // for (int i = 0; i < boolArray.Length; i++) {
            //     if (i % 2 == 0) {
            //         boolArray[i] = true;
            //     } else {
            //         boolArray[i] = false;
            //     }
            // }
            // foreach (bool item in boolArray)
            // {
            //     Console.WriteLine(item);
            // }

            // Generate a 2 dimensional array representing the multiplication tables.
            // Setup the first row.
            // int [,] multTable = new int[10,10];
            // for (int i = 0; i < 10; i++) {
            //     for (int j = 0; j < 10; j++) {
            //         multTable[i,j] = (i+1) * (j+1);
            //     }
            // }
            // // Print the damn thing!
            // for (int i = 0; i < 10; i++) {
            //     for (int j = 0; j < 10; j++) {
            //         Console.Write(string.Format("{0} ", multTable[i,j]));
            //     }
            //     Console.Write(Environment.NewLine);
            // }

            //Create a list of 5 things, output length, output and remove third item, output length.
            // List<object> games = new List<object> {"Dark Souls 1", "Dark Souls 2", "Dark Souls 3", "Bloodborne", "Demon Souls"};
            // Console.WriteLine(games.Count);
            // Console.WriteLine(games[2]);
            // games.Remove(games[2]);
            // Console.WriteLine(games.Count);

            //String-string dictionary, add names from array as keys with null value, then select random item from previous list as value. Print results.
            string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            List<object> games = new List<object> {"Dark Souls 1", "Dark Souls 2", "Dark Souls 3", "Bloodborne", "Demon Souls"};
            Dictionary<string,string> dict = new Dictionary<string,string>();
            Random ayn = new Random();
            foreach (string name in nameArray) {
                dict.Add(name, null);
            }
            List<string> keys = new List<string>(dict.Keys);
            foreach (string key in keys){
                int rand = ayn.Next(0,games.Count-1);
                dict[key] = games[rand] as string;
                Console.WriteLine("Key: {0}, Entry: {1}", key, dict[key]);
            }
        }
    }
}
