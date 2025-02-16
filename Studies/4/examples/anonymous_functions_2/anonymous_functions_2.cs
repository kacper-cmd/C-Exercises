using System;
using System.Collections.Generic;
using System.Linq;

    class Anonymous_functions_2
    {
        static void Main(string[] args)
        {            
            // use anonymous function and lambda expression to handle 'callMeeting, event
            // in Group class (look at a code of add() methods)
            Example1(); 

            // to ForEach method pass a parameter being lambda expression
            Example2();
                        
            // using delegates and existing methods for arrays
            // find the lowest person in given array (if is more than one, get the first of them)
            Example3();
        }

        static void Example1()
        {
            Person szef = new Person("Jan", "Kowalski", false,  177, 87);
            Person jakub = new Person("Kuba", "Nowak", false, 177, 87);
            Person osoba1 = new Person("Julia", "Nowak", true, 155, 60);
            Person osoba2 = new Person("Julia", "As", true, 165, 65);
            Person osoba3 = new Person("Tomasz", "Drugi", false, 189, 90);
            Employee osoba4 = new Employee("Mariusz", "Kowal", false, "driver");
            Student osoba5 = new Student("Alicja", "Czarów", true);

            Group club = new Group(10, "Champions club");
            club.add(szef, jakub, osoba1, osoba2, osoba3, osoba4, osoba5);

            club.CallForMeeting();

            Console.ReadLine();
        }

        static void Example2()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Wardrobe", 3000, 0.22f));
            products.Add(new Product("Table", 1000, 0.22f));
            products.Insert(0, new Product("Chair", 700, 0.22f));
            products.RemoveAt(0);

            Console.Clear();
            products[1].print();
            Console.WriteLine();

            Console.WriteLine("Products review");            
            // ways to pass a delegate as a parameter to ForEach method
            // effect is invoking the delegate for each element of a collection
            // here priniting elements

            // using anonymous function as a parameter of a method
            products.ForEach(delegate(Product p) { p.print(); });
            // and a lambda expression
            products.ForEach( p =>  p.print() );

            Console.ReadLine();
        }

        static void Example3()
        {
            Person[] persons = new Person[] { new Person("Jan", "Kowalski", false, 177, 87),
                                          new Person("Kuba", "Nowak", false, 177, 87),
                                          new Person("Julia", "Nowak", true, 155, 60),
                                          new Person("Julia", "As", true, 165, 65),
                                          new Person("Tomasz", "Drugi", false, 189, 90),
                                          new Employee("Mariusz", "Kowal", false, "manager"),
                                          new Student("Alicja", "Czarów", true)           
            };

            // firstly we find the lowest value of height in the group using Min LINQ extension method
            short? theLowest = persons.Min(p => p.Height);
            Console.WriteLine(theLowest);            
            // and secondly we find the first person, which has a found, the lowest value of height
            // and finally we present it (using Show2 method)
            persons.First(p=> p.Height == theLowest).Show2();

            Console.ReadLine();
        }

    }
