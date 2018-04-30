using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a loop that prints all values from 1-255
            // int index = 1;
            // while (index < 256) {
            //     Console.WriteLine(index);
            //     index++;
            // }
            //Create a new loop that prints all values from 1-100 that are divisible by 3, 5, or both.
            // int index = 1;
            // while (index < 101) {
            //     if (index % 3 == 0 || index % 5 == 0) {
            //         Console.WriteLine(index);
            //     }
            //     index++;
            // }
            //Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for multiples of 3 and 5.
            // int index = 1;
            // while (index < 256) {
            //     if (index % 3 == 0 && index % 5 == 0) {
            //         Console.WriteLine("FizzBuzz");
            //     } else if (index % 3 == 0) {
            //         Console.WriteLine("Fizz");
            //     } else if (index % 5 == 0) {
            //         Console.WriteLine("Buzz");
            //     } else {
            //         Console.WriteLine(index);
            //     }
            //     index++;
            // }
            //...not-using modulus?
            // int index = 1;
            // while (index < 256) {
            //     double dividend15 = index/15;
            //     double dividend5 = index/5;
            //     double dividend3 = index/3;
            //     if (dividend15 * 15 == index) {
            //         Console.WriteLine("FizzBuzz");
            //     } else if (dividend5 * 5 == index) {
            //         Console.WriteLine("Buzz");
            //     } else if (dividend3 * 3 == index) {
            //         Console.WriteLine("Fizz");
            //     } else {
            //         Console.WriteLine(index);
            //     }
            //     index++;
            // }
            //Generate 10 random values and output the correct word for each value.
            Random ayn = new Random();
            int index = 1;
            while (index < 10) {
                int random = ayn.Next(1,255);
                if (random % 15 == 0) {
                    Console.WriteLine("{0}: FizzBuzz", random);
                } else if (random % 5 == 0) {
                    Console.WriteLine("{0}: Buzz", random);
                } else if (random % 3 == 0) {
                    Console.WriteLine("{0}: Fizz", random);
                } else {
                    Console.WriteLine(random);
                }
                index++;
            }
        }
    }
}
