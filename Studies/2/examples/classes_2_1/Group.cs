using System;

namespace classes_2_1
{
    class Group
    {        
        public const int MAX_SIZE = 24;
        public static readonly int MIN_SIZE = 6;
        //string name = "NONAME"; // for test, should be private
        public string name { get; set; } = "NONAME"; // autoproperty, can be public
        static int groupsCount;
        Person[] members = new Person[MIN_SIZE];
        
        // Let's assume, that on the first place in the group
        // the group leader is placed. So I define a property
        public Person Leader
        {
            get { return members[0]; }
            set { members[0] = value; }
        }
        
        // indexed property (indexer), which lets us to get (by index) 
        // a member of the group directly
        public Person this[int i]
        {
            get { return members[i]; }
            set { if (i < members.Length) members[i] = value; }
        }

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


        public int Find(string surnameToFind, out int position)
        {            
            int result = 0, i = 0;
            position = -1;
            foreach (Person member in members)                
                if (member?.surname == surnameToFind) // make surname accessible
                {
                    result++;
                    if (position == -1) position = i;
                }
                i++;                
            return result;
        }

        
        public void add2(params Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
                if (members.Length > i) members[i] = persons[i];
        }

        // destructor
        ~Group()
        {
            Console.WriteLine("Destructor of group {0} is executing",
                name);
            groupsCount--;
        }

    } // end of Group class definition
} // end of namespace
