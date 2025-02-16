using System;

namespace group_person
{
    public partial class Group
    {
        public const int MAX_SIZE = 24;
        public static readonly int MIN_SIZE = 6;
        string name = "NONAME";
        static int groupsCount;
        Person[] members = new Person[MIN_SIZE];

        public string Name => name;
        
        public Person Leader
        {
            get { return members[0]; }
            set { members[0] = value; }
        }

        public Person this[int i]
        {
            get { return members[i]; }
            set { if (i < members.Length) members[i] = value; }
        }
        
        
        // constructors (as you see a constructor is polymorphic)
        // 1.
        public Group()
        {
            groupsCount++;
            //Console.WriteLine("\nGroup number {0} is created", groupsCount);
        }

        // 2.
        public Group(int capacity)
            : this() // uses constructor 1.
        {
            members = new Person[capacity];
        }

        // 3.
        public Group(int capacity, string name) : this(capacity)
        {            
            this.name = name;            
        }

        // 4.
        public Group(string name, params Person[] persons)
            : this(persons.Length, name) // uses constructor 3.
        {
            for (int i = 0; i < members.Length; i++)
            {                                
                members[i] = persons[i];                
            }
        }

        // static constructor
        static Group()
        {
            Console.WriteLine("\nStatic constructor of Group welcome\n");
        }
        
        // polymorphic method add()

        // version 1: adds a person to a given position in the group
        // (without checking if pos is valid)
        public void add(Person newPerson, int pos)
        {
            members[pos] = newPerson;
        }
        
        // version 2: adds to the first free place in the group
        // without checking if there is free place in the group
        public void add(Person newPerson)
        {
            int i = 0;
            while (this.members[i] != null) i++;
            //this.members[i] = newPerson;
            this[i] = newPerson; // using indexer
        }
        
        // version 2b: it will be treated as wrong duplicate
        // because parameters count and types are the same as in version 2
        // note that other result type doesn't matter
        //public Person add(Person newPerson) { return null; }
        
        // version 3: adds any number of persons (thanks to params modifier)
        public void add(params Person[] newPersons)
        {            
            int i = 0;
            while (this.members[i] != null) i++;
            foreach (Person newPerson in newPersons) { add(newPerson, i); i++; }            
        }

        // returns how many places is occupied
        public int nonEmptyPlacesCount()
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

        // destructor
        ~Group()
        {
            Console.WriteLine("Destructor of group {0} is executing", name);
            groupsCount--;
        }        

    } // end of Group class definition
} // end of namespace
