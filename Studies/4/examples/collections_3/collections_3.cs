using System;
using System.Collections.Generic;

namespace collections_3
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

    class Collection_3
    {
        static void Main(string[] args)
        {

            // basic operations on Queue<T> 
            Console.WriteLine("Queue test");
            Console.WriteLine("===============================================");
            {                
                Queue<Product> products = new Queue<Product>();
                products.Enqueue(new Product("Wardrobe", 3000, 0.22f));
                products.Enqueue(new Product("Table", 1000, 0.22f));
                products.Enqueue(new Product("Chair", 700, 0.22f));
                products.Dequeue();                
                products.Peek().print();
                Console.WriteLine();

                Console.WriteLine("Printing items of Queue");
                foreach (Product Product in products) // like an array,but there is no access by index
                {
                    Console.WriteLine("Key = {0}, Value = {1}", '?', Product);
                }
                Console.WriteLine();
                
                /* or like this
                int i = 0;
                foreach (Product Product in products)
                {
                    Console.WriteLine("Key = {0}, Value = {1}",
                        i, products.ToArray()[i++].ToString());
                }
                Console.WriteLine();
                */
            }            


            // basic operations on Stack<T>
            Console.WriteLine("Stack test");
            Console.WriteLine("===============================================");
            {
                Stack<Product> products = new Stack<Product>();
                products.Push(new Product("Wardrobe", 3000, 0.22f));
                products.Push(new Product("Table", 1000, 0.22f));
                products.Push(new Product("Chair", 700, 0.22f));
                products.Pop();                
                products.Peek().print();
                Console.WriteLine();

                Console.WriteLine("Printing items of Stack");
                // like for Queue or like below, using an enumerator
                Stack<Product>.Enumerator navigator = products.GetEnumerator();
                while (navigator.MoveNext()) navigator.Current.print();
                navigator.Dispose();                
                Console.WriteLine();                
            }            

            Console.ReadLine();            
        }
    }
}
