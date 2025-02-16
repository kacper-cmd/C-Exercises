using System;
using System.Text;

// Class members: methods

namespace classes_1_2
{
    
    class Person
    {
        // I have no constructor for now
        // so I must use public (or internal) fields
        // it isn't good practice, we change it later
        internal string name;
        public string surname;
        public short height;
        public float weight;
        public bool female;

        //    
        // a method
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, is {2} cm height, "
                              + " and {3} kg weight",
                              name, surname, height, weight,
                              female ? "female" : "male");
        }
    }

    class Group
    {        
        public const int MAX_SIZE = 24;        
        public static readonly int MIN_SIZE = 10;
        public string name = "NONAME";
        public static int groupsCount;
        public Person[] members = new Person[MIN_SIZE];

        // adds a person to a group
        // (without checking if it is possible)
        public void Add(Person newPerson, int pos)
        {
            members[pos] = newPerson;
        }

        //private method 
        int nonEmptyPlacesCount()
        {
            int result = 0;
            foreach (Person member in members)
                if (member != null) result++;
            return result;
        }

        public void Show()
        {
            Console.WriteLine("\nGroup nr {1} of name {0}. Persons:"
                , name, Group.groupsCount);
            foreach (Person member in members)
                if (member != null) member.Show();
                else Console.WriteLine("FREE PLACE");

            Console.WriteLine("In this group is {0} occupied places",
                nonEmptyPlacesCount());
        }
    }

    class Test
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Example 1.(operations on class members)" +
                            "\n========================================================\n");
            
            // creating an object for test
            Person friend = new Person();
            friend.name = "Jan";

            // calling (invoking) a method for this object
            // data of the object have default values (except name)            
            friend.Show();


            // preparing second object
            Person boss = new Person();
            boss.name = "Janina";
            boss.surname = "Kloss";
            boss.height = 175; 
            boss.weight = 68.55f; 
            boss.female = true; 

            boss.Show();

            // operations on Group object
            Group g1 = new Group();
            g1.Add(friend, 0);
            g1.Add(boss, 1);
            g1.Show();
            //g1.nonEmptyPlacesCount();

            Console.ReadLine();
        }
    }

}
