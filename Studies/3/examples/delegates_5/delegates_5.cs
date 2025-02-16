using System;

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

            Group club = new Group("Champions Club", boss, brother, person1, person2, person3, person4, person5);
            club.Show2();    

            // generates an event
            // it means invocation of all methods added to meeting 'event'
            club.CallForMeeting();

            Console.ReadLine();
        }
        
    }
