using System;
using System.Collections.ObjectModel;

namespace collection_4
{
    class Product
    {
        string name;
        decimal price;
        float vat;

        public Product(string n, decimal p, float v) { name = n; price = p; vat = v; }
        public void print() { Console.WriteLine("{0}, {1}zł, vat {2:p}", name, price, vat); }
        public override string ToString() { return String.Format("{0}, {1} zł, vat {2:p}", name, price, vat); }

        public string Key() { return name; } // this method returns a key of an item for KeyedCollection 
    }


    class Warehouse : KeyedCollection<string, Product>
    {
     // below method defines way of key generating (e. g. from an item value)
        protected override  string  GetKeyForItem(Product p)
        {
            return p.Key();
        }        
    }

    class Collections_4
    {
        static void Main(string[] args)
        {

            // basic operations on KeyedCollection
            Console.WriteLine("Test of Warehouse container type (based on KeyedCollection<K, V>");
            Console.WriteLine("========================================================================");
            {                
                Warehouse products = new Warehouse();
                products.Add(new Product("Wardrobe", 3000, 0.22f));
                products.Add(new Product("Table", 1000, 0.22f));
                products.Add(new Product("Chair", 700, 0.22f));
                products.RemoveAt(1);                
                products[1].print();
                Console.WriteLine();

                Console.WriteLine("Printing items of Warehouse container");                    
                // by keys
                foreach (Product Product in products) 
                {
                    Console.WriteLine("Key = {0}, Value = {1}", Product.Key(), Product);
                }
                Console.WriteLine();

                // and by indexes
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine("Index = {0}, Value = {1}", i, products[i]);
                }
                Console.WriteLine();
            }            
                       
            Console.ReadLine();            
        }
    }
}
