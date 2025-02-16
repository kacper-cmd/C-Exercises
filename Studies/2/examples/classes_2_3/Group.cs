using System;
using System.Text;

namespace classes_2_3
{
    class Group
    {
        public const int MAX_SIZE = 24;
        public static readonly int MIN_SIZE = 6;
        string name = "NONAME";
        static int groupsCount;
        Person[] members = new Person[MIN_SIZE];
        
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
                // deep copy for arrays, but shallow one for elements
                members[i] = persons[i];
                // deep copy for elements is not to do here
                // because of access to person data                
                //members[i] = new Person(persons[i].name, persons[i].surname, 
                //                        persons[i].height, persons[i].weight, persons[i].female);
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
            Console.WriteLine("\nGroup of name {0}. Persons:", name);
            foreach (Person member in members)
                if (member != null) member.Show();
                else Console.WriteLine("FREE PLACE");
        }
        
        public virtual void Show2()
        {
            Console.WriteLine("\nGroup of name {0}. Persons:", name);
            foreach (Person member in members)
                if (member != null) member.Show2(); // here is difference, a virtual method is used to display members of the group
                else Console.WriteLine("FREE PLACE");
        }
        
        // 'as' and 'is' operators: 
        public void Show3()
        {
            Console.WriteLine("\nGroup of name {0}. Persons:", name);
            int personCount = 0, employeeCount = 0, studentCount = 0;
            foreach (Person member in members)                
                {
                    personCount++;
                    // explicit conversion Person --> Student below
                    if (member is Student) { ((Student)member).Show(); studentCount++; }
                    else
                        // and here other way of conversion, using 'as' operator
                        // differrence is visible on invalid conversion 
                        if (member is Employee) { (member as Employee).Show(); employeeCount++; }
                        else
                            member.Show();
                }
            Console.WriteLine("Persons {0}, employees {1}, students {2}",
                              personCount, employeeCount, studentCount);
        }

        // destructor
        ~Group()
        {
            Console.WriteLine("Destructor of group {0} is executing", name);
            groupsCount--;
        }

        // OPERATORS
        // methods overloading + operator 

        // adding two groups 
        public static Group operator +(Group g1, Group g2)
        {
            Group sum = new Group(g1.members.Length + g2.members.Length);
            foreach (Person member in g1.members) sum.add(member);
            foreach (Person member in g2.members) sum.add(member);
            
            return sum;
        }

        // adding a person to the group
        public static Group operator +(Group g, Person who)
        {
            g.add(who);
            return g;
        }

        // true and false operators - used to detect nonempty group
        public static bool operator true(Group g)
        {
            foreach (Person member in g.members)
                if (member != null) return true;
            return false;
        }
        public static bool operator false(Group g)
        {
            foreach (Person member in g.members)
                if (member != null) return false;
            return true;
        }

    } 
} 
