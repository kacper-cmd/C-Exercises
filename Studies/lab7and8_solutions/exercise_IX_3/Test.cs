using System;

namespace group_person
{
    class Test
    {
        static void Main(string[] args)
        {                
          // objects for tests 
            Person friend = new Person("Jan","Nowak",false,180,90);            
            Person boss = new Person("Janina","Kloss",true,175,68.55f);            
            Person colleague = new Person("Agata","Nowak", true, 170, 66.66f);            
            Person Person1 = new Person("Andrzej", "Kochanowski", false, 190, 100);
            Person Person2 = new Person("Kalina", "Bez", true, 155, 45);          
            Person Person3 = new Person("Adam", "Nowak", false, 180, 90);

            Person Person4 = new Student("Anna", "Smith", true);
            Student Person5 = new Student("Marta", "Kowalska", true);
            Person Person6 = new Employee("Andrzej", "Jones", false, "kadrowy");
            Employee Person7 = new Employee("Halina", "Bond", true, "kierowca");

            // test of IX.3
            Group g = new Group("Friends", friend, Person4, Person6);
            g.present = g.Show;
            g.present();

            g.present = g.Show2;
            g.present();

            g.present = g.Show3;
            g.present();

            Console.ReadLine();
        }
    }
}