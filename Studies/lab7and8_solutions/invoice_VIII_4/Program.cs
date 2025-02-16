﻿using System;
using group_person;
using product;

namespace invoice
{
    class Ex_III_7
    {
        static void Main(string[] args)
        {
            Product car = new Product("Car", 20000, "piece", new DateTime(2019, 4, 11), 0.07f, 0.1f);
            Sale s1 = new Sale(car, 7, 30000);
            s1.print();
            Console.WriteLine();

            Sale s2 = new Sale(new Product("Laptop XYZ", 1000, "item", new DateTime(2020, 1, 11), 0.23f, 0.05f), 10, 1600);

            Invoice invoice1 = new Invoice(DateTime.Now, new Person("Agata", "Nowak", 0, 0, true));
            invoice1.addPosition(s1);
            invoice1.addPosition(s2);
            invoice1.addPosition(new Sale(new Product("Hard disc", 400, "item", DateTime.Today, 0.07f, 0.09f), 20, 2000));
            invoice1.print();
            Console.WriteLine();

            // test of VIII.4a
            decimal x = (decimal)invoice1;
            Console.WriteLine($"Invoice as decimal: {x:c}");
            Console.WriteLine();
            // test of VIII.4b
            Product[] data = new Product[]
            {
                car,
                new Product("Laptop XYZ", 1000, "item", new DateTime(2020, 1, 11), 0.23f, 0.05f),
                new Product("Hard disc", 400, "item", DateTime.Today, 0.07f, 0.09f)
            };
            Invoice invoice2 = data;
            invoice2.print();

            Console.ReadLine();
        }
    }
}
