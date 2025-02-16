using System;

// Class members: fields and constant values

namespace classes_1_1
{
    // default access modifier to a class is internal
    class Person
    {        
        // fields with various access modifiers

        public string surname;
        // internal is public for an assembly (in one file)
        internal string name;
        protected float weight;
        private bool female;
        // default access modifier to a class member is private
        short height;        
    }

    class Group
    {        
        public const int MAX_SIZE = 24;        
        // difference from constant value, you can use other variables
        public static readonly int MIN_SIZE = groupsCount>5?15:10;
        public string name = "NONAME";
        public static int groupsCount;
        public Person[] members;
    }

    class Test
    {

        static void Main(string[] args)
        {
         Console.WriteLine("Example 1.(creating objects and using their features)" +
                           "\n========================================================\n");
                  
         // creating an object and allocating a memory (new)

         Person friend;
         friend = new Person();

         // reference to class member (successfull if this member is accessible here)
         friend.name = "Jan";

         Console.WriteLine("My friend is {0} {1}",friend.name, friend.surname);
         
         // height and weight are inaccessible, below is invalid
         /*
            Console.WriteLine("My friend is {4}, {0} {1}, he is {2} cm height, " 
                               + " and {3} kg weight",
                               friend.name, friend.surname, friend.height, friend.weight,
                               friend.female?"Female":"Male");
         */
        
         // second object

          Person boss = new Person();
                
          boss.name = "Janina";
          boss.surname = "Kloss";
          //boss.height = 175; // inaccessible
          //boss.weight = 68.55; // inaccessible
          //boss.female = true; //  inaccessible
          Console.WriteLine("Szef to {0} {1}", boss.name, boss.surname);                       
          // test above by changing modifiers
                    
          // creating and operating with object of Group class
          Console.WriteLine("\nMaximum number of persons in group is: {0}", Group.MAX_SIZE);
          Group g = new Group();
          Console.WriteLine("Group nr {1} of name {0}. Members:",g.name,++Group.groupsCount);
          g.members = new Person[] { friend, boss };
          //g.members[0] = friend;
          //g.members[1] = boss;
          foreach (Person member in g.members) 
              Console.WriteLine("{0} {1}", member.name, member.surname);

          
          // constants: can be used only for value types and strings,
          // values of other types can't be evaluated in compile-time
          // fortunately, we have readonly fields

          // local constants:
          // declaration (you can more in the same line), in expression you can use other constant
          const int THREE = 3, FOUR = THREE + 1; 
          const string CSHARP = "C#";
        
          // for other types only null value can be assigned
          
          //const Person PERSON1 = new Person(); // invalid
          //const Person BUDDY = friend; // invalid too
          const Person PERSON1 = null; // valid, but what for?
          //const int[] tab={1,2,3}; // invalid (an array is a reference type)
          //const int[] tab = null; // valid, but what for?

          // an usage of local constant
          Console.WriteLine("{0} wersja {1}.0", CSHARP, THREE);
          Console.ReadLine();
         }
      }
}
