using System;

// Classes: inheritance, inheritance and constructors, overloading

namespace group_person
{
    class Test
    {
        static void Main(string[] args)
        {
            // persons for test            
            Person boss = new Person("Jan","Nowak","777 555 666");            
            Person friend = new Person("Janina","Kloss",true,175,68.55f);            

            Console.WriteLine(boss);
            Console.WriteLine(boss.phoneNr);
            Console.WriteLine(friend);

            Employee boss2 = new Employee(boss, "Boss", "111 222 333");
            Console.WriteLine(boss2);
            Console.WriteLine(boss2.phoneNr); // value from Employee

            Person boss3 = new Employee(boss, "Boss", "111 222 333");
            Console.WriteLine(boss3);
            Console.WriteLine(boss3.phoneNr); // value from Person


            Console.ReadLine();
        }
    }
}
