using System;
using System.Collections.Generic;

namespace collections_1
{

    class Product
    {
        string name;
        decimal price;
        float vat;

        public Product(string n, decimal p, float v) { name = n; price = p; vat = v; }
        public void print() { Console.WriteLine("{0}, {1}zł, vat {2:p}", name, price, vat); }
    }


    class Collections_1
    {
        static void Main(string[] args)
        {
            // basic operations on a list (List<T>)  

            List<Product> products1 = new List<Product>();            
            products1.Add(new Product("Wardrobe",3000,0.22f));
            products1.Add(new Product("Table",1000,0.22f));
            products1.Insert(0,new Product("Chair",700,0.22f));
            products1.RemoveAt(0);
            products1[1].print();
            Console.WriteLine();

            Console.WriteLine("Printing items of a container, one by one");
            // as an argument we pass anonymous method (explained later)
            products1.ForEach(delegate(Product t) { t.print(); });
            Console.WriteLine();

         // basic operations on a linked list (LinkedList<T>)  

            LinkedList<Product> products2 = new LinkedList<Product>();
            products2.AddFirst(new Product("Wardrobe", 3000, 0.22f));
            products2.AddLast(new Product("Table", 1000, 0.22f));
            products2.AddAfter(products2.First, new Product("Chair", 700, 0.22f));
            products2.Remove(products2.Last);
            products2.First.Next.Value.print();            
            Console.WriteLine();

            Console.WriteLine("Printing items of a container of LinkedList type");
            LinkedListNode<Product>  element = products2.First;
            while (element != null)
            {
                element.Value.print();
                element = element.Next;
            }
            
            Console.ReadLine();
        }
    }    
}
