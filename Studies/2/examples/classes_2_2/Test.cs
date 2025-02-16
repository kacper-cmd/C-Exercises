using System;

// Classes: inheritance, inheritance and constructors, overloading

namespace classes_2_2
{
    class Test
    {
        static void Main(string[] args)
        {
            // persons for test
            Person emptyPerson = new Person();
            Person boss = new Person("Jan","Nowak");            
            Person friend1 = new Person("Janina","Kloss",true,175,68.55f);                        
            Person friend2 = new Person("Agata","Nowak", true, 170, 66.66f);
            Person person1 = new Person("Andrzej", "Kochanowski", false, 190, 100);
            Person person2 = new Person("Kalina", "Bez", true, 155, 45);

         // test of overloading (Group constructors and add() method)            
            Console.WriteLine("Test of overloading (Group constructors and add() method)\n======================================================================");

            // group for test (constructor 1)
            Group g1 = new Group();
            g1.add(boss, 0);
            g1.add(friend1, 1);
            g1.add(friend2);
            g1.Show();

            // group for test (constructor 2)
            Group g2 = new Group(5);
            g2.add(boss, friend1, friend2, person1);                
            g2.Show();

            // group for test (constructor 3)
            Group g3 = new Group(8, "Friends");
            g3.add(boss, friend1, friend2);
            g3.Show();

            // group for test (constructor 4)
            Group g4 = new Group("Boss & friend", boss, friend2);            
            g4.Show();

            Console.ReadLine();
            Console.WriteLine("\nTest of inheritance StudentGroup from Group\n======================================================");
            
            // an object of derive class
            StudentGroup g5 = new StudentGroup("Project team", person1, person2, boss, friend2);
            // and its method
            g5.ShowStudentGroup();
            
            // for object of subclass you can use members inherited from base class (Group)
            g5.add(friend1, 3);
            g5.Show();
            Console.WriteLine();
            g5.Leader.Show();

            Console.ReadLine();
        }
    }
}
