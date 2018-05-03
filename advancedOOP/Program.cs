using System;
using System.Collections.Generic;

namespace advancedOOP
{
    public interface CanRun {
        int Run();
    }
    public class Product {
        public decimal Price;
    }
    public class ShoppingCart
    {
        public List<Product> Products {get; set;}
    }
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }
            return total;
        }
        public static double MarathonDistance(this CanRun creature)
        {
            creature.Run();
            Console.WriteLine("I'm running a marathon now!");
            return 26.2;
        }
    }
    public static class Calculator
    {
        public static int Add(int x, int y){
            return x + y;
        }
    }
    public class Callbacker {
        public void MethodWithCallBack(int x, int y, Del callback) {
            callback("The number is " + (x+y).ToString());
        }
        public delegate void Del(string message);
        public Del handler = DelegateMethod;
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Calculator.Add(10,15);
            Callbacker call = new Callbacker();
            call.MethodWithCallBack(1,2,call.handler);
        }
    }
}
