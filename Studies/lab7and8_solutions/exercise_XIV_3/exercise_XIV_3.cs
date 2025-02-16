using System;
using System.Collections.Generic;

using System.Linq;

namespace collections_2
{    
    class Product
    {
        string name;
        decimal price;
        float vat;

        public Product(string n, decimal p, float v) { name = n; price = p; vat = v; }

        // needed to XIV.3
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }

        public void print() { Console.WriteLine("{0}, {1}zł, vat {2:p}", name, price, vat); }
        public override string ToString() { return String.Format("{0}, {1} zł, vat {2:p}", name, price, vat); }
    }

    class Collections_2
    {
        static void Main(string[] args)
        {            
            // basic operations on Dictionary<T>
            Console.WriteLine("Dictionary container test");
            Console.WriteLine("===============================================");
            {
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                products.Add("t1", new Product("Wardrobe", 3000, 0.22f));
                products.Add("t2", new Product("Table", 1000, 0.22f));
                products.Add("k", new Product("Chair", 700, 0.22f));                

                Console.WriteLine("Printing items of Dictionary container");
                foreach (KeyValuePair<string, Product> Product in products)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        Product.Key, Product.Value);
                }
                Console.WriteLine();

                // test of XIV.3
                Console.Write("Enter a prefix of product's name: ");
                string prefix = Console.ReadLine();
                var selectedProducts = 
                    products.Where(p => p.Value.Name.StartsWith(prefix));
                decimal totalPrice = selectedProducts.Sum(p => p.Value.Price);
                Console.WriteLine($"Total price of selected products: {totalPrice}");
                selectedProducts.ToList().ForEach(p => p.Value.print());
            }            

            Console.ReadLine();            
        }
    }
}
