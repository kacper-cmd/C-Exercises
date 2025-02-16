using System;

// Test of delegates

    class Test
    {
        static void Main(string[] args)
        {
         // 
            Person boss = new Person("Jan", "Kowalski", false, 177, 87);                        
            Person brother = new Person("Kuba", "Nowak", false, 177, 87);            
            Person person1 = new Person("Julia", "Nowak", true, 155, 60);
            Person person2 = new Employee("Julia", "As", true, "driver");
            Person person3 = new Student("Tomasz", "Drugi", false);
            Employee person4 = new Employee("Mariusz", "Kowal", false, "manager");
            Student person5 = new Student("Alice", "Magic", true);                 

            Group club = new Group(10,"Champions club");
            club.add(boss, brother, person1, person2, person3, person4, person5);

        // invoking of multicast delegate
        // works as generating and propagation an event "The group invites for a meeting"
        // IX.5 see Person_2.cs, Student.cs and Employee.cs to analyse solution of IX.5
            Console.WriteLine("\nResponses from objects-observators to a notification of observed object\n=======================================================");
            club.notification("Invitation for a meeting");

            Console.ReadLine();
        }
        
    }
