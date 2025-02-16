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
            Person person2 = new Person("Julia", "As", true, 165, 65);
            Person person3 = new Person("Tomasz", "Drugi", false, 189, 90);
            Employee person4 = new Employee("Mariusz", "Kowal", false, "manager");
            Student person5 = new Student("Alice", "Magic", true);         

            Group all = new Group("For sorting", boss, brother, person1, person2, person3, person4, person5);
            
            Console.WriteLine("\nThe group before sorting\n===============================");
            all.Show2();

         // creating an instance of delegate 'WhoFirst' and assign Person.whoFirstBySurname method to it       
            WhoFirst comparison = new WhoFirst(Person.whoFirstBySurname);

        // invoking insertSort() method with a parameter - a way how to compare persons
            all.insertSort(comparison);
            Console.WriteLine("\nThe group after sorting\n================================");
            all.Show2();
            Console.WriteLine();
            Console.ReadLine();
            //Console.Clear();


            Group club = new Group(10,"Champions club");
            club.add(boss, brother, person1, person2, person3, person4, person5);        
        // invoking of multicast delegate
        // works as generating and propagation an event "The group invites for a meeting"
            Console.WriteLine("\nResponses from objects-observators to a notification of observed object\n=======================================================");
            club.notification("Invitation for a meeting");

            Console.ReadLine();
        }
        
    }
