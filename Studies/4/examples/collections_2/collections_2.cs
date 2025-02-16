using System;
using System.Collections.Generic;

namespace collections_2
{    
    class Product
    {
        string name;
        decimal price;
        float vat;

        public Product(string n, decimal p, float v) { name = n; price = p; vat = v; }
        public void print() { Console.WriteLine("{0}, {1}zł, vat {2:p}", name, price, vat); }
        public override string ToString() { return String.Format("{0}, {1} zł, vat {2:p}", name, price, vat); }
    }

    class Collections_2
    {
        static void Main(string[] args)
        {

            // basic operations on SortedList<T>
            Console.WriteLine("SortedList container test");
            Console.WriteLine("===============================================");
            {                
                SortedList<string, Product> products = new SortedList<string, Product>();
                products.Add("t1", new Product("Wardrobe", 3000, 0.22f));
                products.Add("t2", new Product("Table", 1000, 0.22f));
                products.Add("k", new Product("Chair", 700, 0.22f));
                products.Remove("t2");
                // or:
                //products.RemoveAt(0);
                products["t1"].print();                
                // but we can't access by an index
                //products[0].print();
                Console.WriteLine();

                Console.WriteLine("Printing items of SortedList container");
                foreach (KeyValuePair<string, Product> Product in products)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        Product.Key, Product.Value);
                }
                Console.WriteLine();
            }
            

            // basic operations on SortedDictionary<T>
            Console.WriteLine("SortedDictionary container test");
            Console.WriteLine("===============================================");
            {
                SortedDictionary<string, Product> products = new SortedDictionary<string, Product>();
                products.Add("t1", new Product("Wardrobe", 3000, 0.22f));
                products.Add("t2", new Product("Table", 1000, 0.22f));
                products.Add("k", new Product("Chair", 700, 0.22f));
                products.Remove("t2");
                //products.RemoveAt(0);
                products["t1"].print();
                Console.WriteLine();

                Console.WriteLine("Printing items of SortedDictionary container");
                foreach (KeyValuePair<string, Product> Product in products)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        Product.Key, Product.Value);
                }
                Console.WriteLine();
            }


            // basic operations on Dictionary<T>
            Console.WriteLine("Dictionary container test");
            Console.WriteLine("===============================================");
            {
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                products.Add("t1", new Product("Wardrobe", 3000, 0.22f));
                products.Add("t2", new Product("Table", 1000, 0.22f));
                products.Add("k", new Product("Chair", 700, 0.22f));
                products.Remove("t2");
                //products.RemoveAt(0);
                products["t1"].print();
                Console.WriteLine();

                Console.WriteLine("Printing items of Dictionary container");
                foreach (KeyValuePair<string, Product> Product in products)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        Product.Key, Product.Value);
                }
                Console.WriteLine();
            }

            Console.ReadLine();            
        }
    }
}
