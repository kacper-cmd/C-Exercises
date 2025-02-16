﻿using System;

    class Group<TMember> where TMember : Person
    {
        public const int MAX_SIZE = 24;
        public static readonly int MIN_SIZE = 6;
        string name = "NONAME";
        static int groupsCount;
        TMember[] members = new TMember[MIN_SIZE];

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TMember Leader
        {
            get { return members[0]; }
            set { members[0] = value; }
        }

        public TMember this[int i]
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
            members = new TMember[capacity];
        }

        // 3.
        public Group(int capacity, string name)
            : this(capacity)
        {
            this.name = name;
        }

        // 4.
        public Group(string name, params TMember[] persons)
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
        public void add(TMember newMember, int pos)
        {
            members[pos] = newMember;
        }

        // version 2: adds to the first free place in the group
        // without checking if there is free place in the group
        public void add(TMember newMember)
        {
            int i = 0;
            while (this.members[i] != null) i++;
            //this.members[i] = newMember;
            this[i] = newMember; // using indexer
        }

        // version 2b: it will be treated as wrong duplicate
        // because parameters count and types are the same as in version 2
        // note that other result type doesn't matter
        //public Person add(Person newPerson) { return null; }

        // version 3: adds any number of persons (thanks to params modifier)
        public void add(params TMember[] newMembers)
        {
            int i = 0;
            while (this.members[i] != null) i++;
            foreach (TMember newMember in newMembers) { add(newMember, i); i++; }
        }

        // returns how many places is occupied
        public int nonEmptyPlacesCount()
        {
            int result = 0;
            foreach (TMember member in members)
                if (member != null) result++;
            return result;
        }

        public void Show()
        {
            Console.WriteLine("\nGroup of name {0}. Members:", name);
            foreach (TMember member in members)
                if (member != null) member.Show();
                else Console.WriteLine("FREE PLACE");
        }

        public virtual void Show2()
        {
            Console.WriteLine("\nGroup of name {0}. Members:", name);
            foreach (TMember member in members)
                if (member != null) member.Show2(); // here is difference, a virtual method is used to display members of the group
                else Console.WriteLine("FREE PLACE");
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
        public static Group<TMember> operator +(Group<TMember> g1, Group<TMember> g2)
        {
            Group<TMember> sum = new Group<TMember>(g1.members.Length + g2.members.Length);
            foreach (TMember member in g1.members) sum.add(member);
            foreach (TMember member in g2.members) sum.add(member);

            return sum;
        }

        // adding a person to the group
        public static Group<TMember> operator +(Group<TMember> g, TMember who)
        {
            g.add(who);
            return g;
        }

        // true and false operators - used to detect nonempty group
        public static bool operator true(Group<TMember> g)
        {
            foreach (TMember member in g.members)
                if (member != null) return true;
            return false;
        }
        public static bool operator false(Group<TMember> g)
        {
            foreach (TMember member in g.members)
                if (member != null) return false;
            return true;
        }

    } 

