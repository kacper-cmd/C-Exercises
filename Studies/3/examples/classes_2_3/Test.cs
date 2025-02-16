using System;

// inheritance, hiding and overriding 

namespace classes_2_3
{
    class Test
    {
        static void Main(string[] args)
        {
            // test of hiding and overriding

            // 'surname' field changes when an object of subclass of Person is created
            // (XXX for Employee, YYY for Student)
            // After change, previous value of surname is inaccessible
            // ... unless we use FIELDS HIDING
            Console.WriteLine("\n\n== Hiding of fields (surname) ================================\n");            
            {
                Employee manager = new Employee("Janina", "Kloss", true, "manager");
                Console.WriteLine("Surname of manager as a Employee is: {0}", manager.surname);
            }
            {
                // the object below has reference type (or compile-time type) Person
                // and real type (or run-time type) Employee
                // assignment is allowed (as implicit conversion from subclass to base class)
                Person manager = new Employee("Janina", "Kloss", true, "manager"); // implicit conversion to base class
                Console.WriteLine("Surname of manager as a person is: {0}\n", manager.surname);
            }

            Student bestStudent = new Student("Agata", "Nowak", true);
            Console.WriteLine("Surname of best student as a student is: {0}", bestStudent.surname);
            Console.WriteLine("Surname of best student as a person is: {0}", ((Person)bestStudent).surname); // explicit conversion to base class


            //Console.ReadLine();
            Console.WriteLine("\n== Method hiding and overriding ==========================\n");

           // objects for test
            Person friend = new Person("Jan", "Kos", false, 187, 87);
            Person accountant = new Employee("Jan", "Kos", false, "accountant");
            Person student = new Student("Jan", "Kos", false);
                       
           // hidden (non-virtual) method, from which class 
           // it depends on declaration type of the object        
            friend.Show();
            accountant.Show();
            student.Show();
            Console.WriteLine("\n");
           
           // overrided (virtual) method, from which class 
           // it depends on constructor type of the object
            friend.Show2();
            accountant.Show2();
            student.Show2();
            Console.WriteLine("\n");


            //Console.ReadLine();
            Console.WriteLine("\n== Method hiding and overriding 2 ==========================\n");

           // objects for tests
            Person person1 = new Person("Adam", "Nowak", false, 180, 90);
            Person person2 = new Student("Anna", "Smith", true);
            Student person3 = new Student("Marta", "Kowalska", true);
            Person person4 = new Employee("Andrzej", "Jones", false, "HR specialist");
            Employee person5 = new Employee("Halina", "Bond", true, "driver");
           
           // a group consisting of objects of various declaration and real types
            Group g3 = new Group("Team", person1, person2, person3, person4, person5);

           // Show() method for a group executes Show() method for each member of the group
           // This method is defined in Person class and hidden in subclasses
           // In this case Show() from Person class is executed
           // because declaration type of 'members' array is Person
            g3.Show(); Console.WriteLine("\n");
           
           // Show2() method for a group executes Show2() method for each member of the group
           // This method is defined in Person class and overridden in subclasses
           // In this case Show2() from various classes is executed
           // because it depends on real, constructor type of group members
            g3.Show2(); Console.WriteLine("\n");
           
           // Show3() checks a real type of given object, convert to that type
           // and calls Show() method, so it "simulates" virtuality mechanism
            g3.Show3(); Console.WriteLine("\n");

            //Console.ReadLine();
            Console.WriteLine("\n== Method hiding and overriding 3 ==========================\n");           

            // another group for test            
            Group g1 = new Group(8, "Friends");
            g1.add(friend, accountant, person1);
            //g1.Show();
            
            
            // array of various groups 
            Group[] groups = new Group[] {
                    new Group(5),
                    new StudentGroup("Sport team", person1, person2, person3),
                    g3
            };
            foreach (Group g in groups) g.Show();           

           // Although an array has homogeneous type, thanks to virtual method
           // we can implement specific behavior for each kind of group
           // in very simple way (see below)
            foreach (Group g in groups) g.Show2();
           
            //groups[1].Show(); // why method from StudentGroup doesn't execute?
            
            Console.ReadLine();
            
            // test of '+' operator in Group class
            Console.WriteLine("\n== Test of adding operator in Group class =================\n");

            g1.Show();
            g3.Show();

            Group twoGroups = g1 + g3;

            Console.WriteLine("\nSum of two groups");
            twoGroups.Show();
            
            // additionally I add two persons to new group
            twoGroups = twoGroups + accountant + friend;
            Console.WriteLine("\nand after adding of two persons =================");
            twoGroups.Show();
            
            // test of true and false operators in Group class
            // the loop below displays only non-empty groups
            Console.WriteLine("\n== Test of true, false operators in Group class =================\n");

            foreach (Group g in groups) if(g) g.Show2();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}