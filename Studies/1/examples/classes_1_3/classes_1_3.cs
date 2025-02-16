using System;

// Classes: constructors, destructor, method parameters

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

        // constructor which sets only name of a person
        public Person(string n)
        {
            name = n;
        }

        // default constructor
        public Person() {}

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

        // default constructor
        public Group() {}

        // static constructor
        static Group() {
            Console.WriteLine("\nStatic constructor of Group welcome\n");
        }

        // adds a person to a group
        // (without checking if pos is valid)
        public void add(Person newPerson, int pos)
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
            Console.WriteLine("Destructor of group {0} is executing",
                name);
            groupsCount--;
        }

    }

    class Test
    {

        static void Main(string[] args)
        {                
            // creating an object of Person class
            // without constructor (unprofessional)
            /*
            Person friend = new Person();                
            friend.name = "Jan";
            */
            // and using constructor (professional)
            Person friend = new Person("Jan");            
            friend.Show();

            // second object
            // without constructor (unprofessional)
            /*
            Person boss = new Person();
            boss.name = "Janina";
            boss.surname = "Kloss";
            boss.height = 175;
            boss.weight = 68.55f;
            boss.female = true;
            */
            // and using constructor (professional)
            Person boss = new Person("Janina", "Kloss", 175, 68.55f, true);
            boss.Show();
            
            // creating a group using constructor            
            Group g = new Group(10, "Boss & his friends");
            
            Person friend1 = new Person("John", "Depp"
                            , 175, 68.55f, false);
            Person friend2 = new Person("Andrew", "Kloss"
                            , 175, 86f, false);
            Person friend3 = new Person("Sophia", "Depp"
                            , 165, 68.55f, true);
            Person friend4 = new Person("Stuart", "Rooney"
                            , 185, 68.55f, false);

            // adding members to the group using add() method
            g.add(boss,0);
            g.add(friend1, 1);
            g.add(friend2, 2);
            g.add(friend3, 3);
            g.add(friend4, 4);
            g.Show();


            // passing parameters ways
            Group.passingParametersTest(g);


            g = null; // now object g is inaccessible and can be removed, 
                      //observe the destructor execution            
            GC.Collect(); // uncomment to force GC to clear the memory (and call above destructor)


            // test of adding any persons method
            Group g2 = new Group(8, "Friends");
            g2.add2(friend1, friend2, friend3, friend4);
            g2.Show();

            Console.ReadLine();
        }
    }
}
