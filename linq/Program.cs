using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        public class Product {
            public string name;
            public string category;
            public double price;
            public Product(string name, string category, double price) {
                this.name = name;
                this.category = category;
                this.price = price;
            }
        }
        static void Main(string[] args)
        {
            Product[] products = new Product[] {
                new Product("jeans","clothing",24.7),
                new Product("socks","clothing",8.12),
                new Product("scooter","vehicle",99.99),
                new Product("skateboard","vehicle",24.99)
            };
            var foundProducts = from match in products
                                orderby match.price descending
                                select new {match.name, match.price};
            List<string> StringList = new List<string> {
                "apple",
                "banana",
                "carrot",
                "asparagus",
                "tomato",
                "artichoke"
            };
            IEnumerable<string> TransformedList = StringList.Where(str => {
                if(str[0] == 'a') { return true; }
                else { return false; }
            });
            IEnumerable<char> TransformedList2 = StringList.Select(str => str[0]);

            //Example of join.
            List<string> Food = new List<string> {
                "apple",
                "banana",
                "carrot",
                "fudge",
                "tomato"
            };
            List<string> Adjective = new List<string> {
                "tasty",
                "capital",
                "best",
                "typical",
                "flavorful",
                "toothsome"
            };
            List<string> Combo = Food.Join(Adjective, 
                                        foodItem => foodItem[0], 
                                        adjective => adjective[0],
                                        (foodItem, adjective) => 
                                        {
                                            return adjective + " " + foodItem;
                                        }).ToList();
        }
    }
}