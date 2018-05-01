using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            to255();
            oddTo255();
            runningSum();
            iterate(new object[] {"dog", 1, 7, "cat", 3.5});
            Console.WriteLine(findMax(new int[] {-1,5,7,3,111,-15}));
            Console.Write(string.Join(", ", oddArray()));
            Console.WriteLine(greater(6,new int[] {7,3,-1,100,2,7}));
            Console.Write(string.Join(", ", square(new int[] {-1,-1,-1,2,8})));
            Console.Write(string.Join(", ", nonNegative(new int[] {-1,-1,-1,2,8})));
            statistics(new int[] {1,2,3,4,5,6,7,8});
            Console.Write(string.Join(", ", shift(new int[] {1,2,3,4,5,6,7})));
            Console.Write(string.Join(", ", toString(new List<object> {-1,3,5,-2,7})));
        }
        public static List<object> toString(List<object> list){
            for (int i = 0; i < list.Count; i++) {
                if (list[i] is int && (int)list[i] < 0) {
                    list[i] = "negative";
                }
            }
            return list;
        }
        public static int[] shift(int[] arr) {
            if (arr.Length == 1) {
                return arr;
            } else {
                for (int i=0; i < arr.Length-1; i++) {
                    arr[i] = arr[i+1];
                }
                arr[arr.Length-1] = 0;
                return arr;
            }
        }
        public static void statistics(int[] arr){
            int max = findMax(arr);
            int sum = 0;
            double average = 0;
            foreach (int value in arr) {
                sum += value;
            }
            average = sum / (double) arr.Length;
            Console.WriteLine("Max: {0}, Sum: {1}, Average: {2}", max, sum, average);
        }
        public static int[] nonNegative(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < 0) {
                    arr[i] *= -1;
                }
            }
            return arr;
        }
        public static int[] square(int[] arr){
            for(int i=0; i < arr.Length; i++){
                arr[i] *= arr[i];
            }
            return arr;
        }
        public static void to255() {
            for (int i=1; i<256; i++){
                Console.Write("{0} ", i);
            }
        }
        public static void oddTo255() {
            for (int i=1; i<256; i+=2) {
                Console.Write("{0} ", i);
            }
        }
        public static void runningSum() {
            int sum = 0;
            for (int i = 0; i < 256; i++) {
                sum += i;
                Console.WriteLine("Now: {0} -- Sum: {1}", i, sum);
            }
        }
        public static void iterate(object[] arr) {
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write("{0}, ", arr[i]);
            }
            Console.Write("}");
        }
        public static int findMax(int[] arr) {
            int max = arr[0];
            foreach (int value in arr) {
                if (value > max) {
                    max = value;
                }
            }
            return max;
        }
        public static double getAverage(int[] arr) {
            double average = 0;
            foreach (int value in arr) {
                average += value;
            }
            average /= arr.Length;
            return average;
        }
        public static List<int> oddArray() {
            List<int> arr = new List<int>();
            for (int i=1; i < 256; i += 2) {
                arr.Add(i);
            }
        return arr;
        }
        public static int greater(int y, int[] arr){
            int count = 0;
            foreach (int value in arr) {
                if (value > y) {
                    count++;
                }
            }
            return count;
        }
    }
}
