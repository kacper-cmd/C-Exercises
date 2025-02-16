using System;

// Classes: method parameters

namespace classes_1_3
{
    // public means that this class may be used
    // outside this assembly (project)
    public class Person
    {
        internal string name;
        public string surname;
        public short height;
        public float weight;
        public bool female;

        // constructor
        public Person(string name, string s, short height, float weight, bool female)
        {
            this.name = name;
            surname = s;
            this.height = height;
            this.weight = weight;
            this.female = female;
        }

        // constructor which sets only name and surname of a person
        public Person(string n, string s)
        {
            name = n;
            surname = s;
        }

        // default constructor
        public Person() { }

        //    
        // a method
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight,
                              female ? "female" : "male");
        }

    }

    partial class Group
    {                    
        public const int MAX_SIZE = 24;
        public static readonly int MIN_SIZE = 6;
        public string name = "NONAME";
        public static int groupsCount;
        public Person[] members = new Person[MIN_SIZE];

        // constructor
        public Group(int places, string name)
        {
            members = new Person[places];
            this.name = name;
            groupsCount++;
        }

        // other constructor
        public Group(Person[] members)
        {
            this.members = (Person[])members.Clone();
            groupsCount++;
        }

        // default constructor
        public Group() { groupsCount++; }

        // static constructor
        static Group()
        {
            Console.WriteLine("\nStatic constructor of Group welcome\n");
        }

        // adds a person to a group
        // (without checking if pos is valid)
        // pos is an optional parameter
        public void add(Person newPerson, int pos = 0)
        {
            members[pos] = newPerson;
        }

        // returns how many places is occupied
        //public 
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
        }
        
        // destructor, automatically called by Garbage Collector (GC)
        // when the object is removing from memory
        ~Group()
        {
            Console.WriteLine("Destructor of group {0} is executing", name);
            groupsCount--;
        }

    }

    class Test
    {
        static void Main(string[] args)
        {                
            
            Person boss = new Person("Janina", "Kloss", 175, 68.55f, true);                                    
            Person friend1 = new Person("John", "Depp"
                            , 175, 68.55f, false);
            Person friend2 = new Person("Andrew", "Kloss"
                            , 175, 86f, false);
            Person friend3 = new Person("Sophia", "Depp"
                            , 165, 68.55f, true);
            Person friend4 = new Person("Stuart", "Rooney"
                            , 185, 68.55f, false);

            // creating a group using constructor            
            Group g = new Group(10, "Boss & his friends");

            // adding members to the group using add() method
            g.add(boss);    // using an optional parameter, default position is 0
            g.add(friend1, 1);
            g.add(pos: 2, newPerson: friend2); // using named parameters
            g.add(friend3, 3);
            g.add(friend4, 4);
            g.Show();

            // test of searching surnames method
            int firstOccurence = -1;
            int countOfDepps = g.Find("Depp", firstOccurence);
            //int countOfDepps = g.Find("Depp", ref firstOccurence);
            //int countOfDepps = g.Find("Depp", out firstOccurence);
            Console.WriteLine("\nIn group {0} given surname occured {1} times.\n"
                               + "Position of first one is: {2}"
                               , g.name, countOfDepps, firstOccurence);            

            // test of adding any persons method
            // you can put to add2() method any number of parameters (of type Person)
            Group g2 = new Group(8, "Friends");
            g2.add2(friend1, friend2, friend3, friend4);
            g2.Show();

            Console.ReadLine();
        }
    }
}
