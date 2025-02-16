using System;

namespace group_person
{
    class Test
    {
        static void Main(string[] args)
        {
            // persons for test
            Person boss = new Person("Jan","Nowak");            
            Person friend1 = new Person("Janina","Kloss",true,175,68.55f);                        
            Person friend2 = new Person("Agata","Nowak", true, 170, 66.66f);
            Person person1 = new Person("Andrzej", "Kochanowski", false, 190, 100);
            Person person2 = new Person("Kalina", "Bez", true, 155, 45);

         // test of overloading (Group constructors and add() method)            
            Console.WriteLine("Test of overloading (Group constructors and add() method)\n======================================================================");

            Group g1 = new Group(5);
            g1.add(boss, 0);
            g1.add(friend1, 1);
            g1.add(friend2);
            g1.Show();

            Group g2 = new Group(5, "Boss & friends");
            g2.add(boss, friend1, friend2, person1);                
            g2.Show();
            
            Console.WriteLine();
            
            // test of V.3b
            // before this test add property Name to Group class
            // which gets public access to name field
            Console.WriteLine(g1 > g2?$"Group {g1.Name} is greater than {g2.Name}":
                $"Group {g1.Name} is NOT greater than {g2.Name}");
            Console.WriteLine(g1 < g2 ? $"Group {g1.Name} is less than {g2.Name}" :
                $"Group {g1.Name} is NOT less than {g2.Name}");
            Console.WriteLine();

            g1.add(person1);
            Console.WriteLine(g1 > g2 ? $"Group {g1.Name} is greater than {g2.Name}" :
                $"Group {g1.Name} is NOT greater than {g2.Name}");
            Console.WriteLine(g1 < g2 ? $"Group {g1.Name} is less than {g2.Name}" :
                $"Group {g1.Name} is NOT less than {g2.Name}");
            Console.WriteLine();

            g1.add(person2);
            Console.WriteLine(g1 > g2 ? $"Group {g1.Name} is greater than {g2.Name}" :
                $"Group {g1.Name} is NOT greater than {g2.Name}");
            Console.WriteLine(g1 < g2 ? $"Group {g1.Name} is less than {g2.Name}" :
                $"Group {g1.Name} is NOT less than {g2.Name}");
            Console.WriteLine();

            Console.ReadLine();            
        }
    }
}
