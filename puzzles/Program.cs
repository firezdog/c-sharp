using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // randomArray();
            // Console.WriteLine(multiCoinFlip(100));
            Console.WriteLine(String.Join(", ", strings()));
        }

        /*Build a function Names that returns an array of strings
        Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        Shuffle the array and print the values in the new order
        Return an array that only includes names longer than 5 characters */
        public static string[] strings() {
            string[] names = new string[5] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random ayn = new Random();
            for (int i = 0; i < names.Length; i++) {
                int random = ayn.Next(0,names.Length-1);
                string temp = names[i];
                names[i] = names[random];
                names[random] = temp;
            }
            foreach (string name in names) {
                Console.WriteLine(name);
            }
            List<string> namesList = new List<string>(names);
            for (int i = 0; i < namesList.Count; i++) {
                if (namesList[i].Length < 6) {
                    namesList.Remove(namesList[i]);
                }
            }
            names = namesList.ToArray();
            return names;
        }

        /*Create another function called TossMultipleCoins(int num) that returns a Double
        Have the function call the tossCoin function multiple times based on num value
        Have the function return a Double that reflects the ratio of head toss to total toss */
        public static double multiCoinFlip(int tosses) {
            Dictionary<string,float> results = new Dictionary<string, float>() {
                {"heads", 0},
                {"tails", 0}
            };
            while (tosses > 0) {
                results[coinFlip()]++;
                tosses--;
            }
            return results["heads"] / results["tails"];
        }

        /*Create a function called TossCoin() that returns a string
        Have the function print "Tossing a Coin!"
        Randomize a coin toss with a result signaling either side of the coin 
        Have the function print either "Heads" or "Tails"
        Finally, return the result */
        public static string coinFlip() {
            string result = "";
            Console.WriteLine("Tossing a coin!");
            Random ayn = new Random();
            if (ayn.NextDouble() < 0.5) {
                result = "heads";
            } else {
                result = "tails";
            }
            Console.WriteLine(result);
            return result;
        }

        /*Random Array
        Create a function called RandomArray() that returns an integer array
        Place 10 random integer values between 5-25 into the array
        Print the min and max values of the array
        Print the sum of all the values */
        public static int[] randomArray(){
            int[] randomNumbers = new int[10];
            Random ayn = new Random();
            for (int i=0; i<10; i++){
                randomNumbers[i] = ayn.Next(5,25);
            }
            int min = randomNumbers[0];
            int max = randomNumbers[0];
            int sum = 0; 
            for (int i =0; i<10; i++) {
                sum += i;
                if (randomNumbers[i] > max) {
                    max = randomNumbers[i];
                }
                if (randomNumbers[i] < min) {
                    min = randomNumbers[i];
                }
            }
            Console.WriteLine($"The max is {max}, the min is {min}, and the sum is {sum}");
            return randomNumbers;
        }

    }
}
