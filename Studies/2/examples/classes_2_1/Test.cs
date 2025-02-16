using System;

namespace classes_2_1
{
    class Test
    {
        static void Main(string[] args)
        {
            // persons for tests
            Person friend = new Person("Jan", "Nowak", 180, 90, false);
            Person boss = new Person("Janina", "Kloss", 175, 68.55f, true);
            Person guest = new Person("Agata", "Nowak", 170, 66.66f, true);            

            // groups for tests
            Group g1 = new Group();
            g1.add(friend, 0);
            g1.add(boss, 1);
            g1.add(guest, 2);
            g1.Show();
                                  
            Group g2 = new Group(8, "Koledzy");                
            g2.add2(friend, boss, guest);                
            g2.Show();

            // test of Leader property
            Console.WriteLine("\nTest of Leader property\n===================================");
            Console.Write("\nThe leader of group {0}: ", g2.name);
            g2.Leader.Show();            
            g2.Leader = boss;
            Console.Write("Leader of group {0} after change: ", g2.name);
            g2.Leader.Show();

            // test of properties from Person class
            Console.WriteLine("\nTest of properties of Person class\n===================================");
            Console.WriteLine($"Before change: {guest.FullName}");
            guest.Name = "Agat";
            guest.Sex = "facet";
            Console.Write("After change: ");
            guest.Show();
            Console.WriteLine();

            // test of indexer from Person class            
            Console.WriteLine("\nTest of indexer from Person class\n===================================");
            for(byte i = 0; i<5; i++) Console.Write(friend[i] + "\t");
            Console.WriteLine();

            // test of indexer from Group class            
            Console.WriteLine("\nTest of indexer from Group class\n===================================");
            g1[1].Show();

            Console.Write("\nTest of indexers from Group and Person classes\n===================================");
            Group[] groups = new Group[] { g1, g2 };
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].Show();    // shows the group
                groups[i][0].Show(); // shows first member of the group
                // test of indexer from Person class
                Console.WriteLine(groups[i][0][1]); // shows surname of first member lof the group
            }

            Console.ReadLine();
        }
    }
}
