using System;

namespace classes_3_1
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
                  
        // test of Salary struct (see Employee.cs)
            Console.WriteLine("\n=== Test of Salary struct ============================\n");
            Person7.SetSalary(2700m, 1000M, 2.5m, 23);
            Person7.ShowWithSalary();
        
        // Test of nested type and Signature struct (see StudentGroup.cs)
            Console.WriteLine("\n\n=== Test of nested type and Signature struct ===========\n");
            StudentGroup students = new StudentGroup("",Person1, Person2, friend, colleague);
            students.Name = StudentGroup.Signature.UNIVERSITY;
            students.Show();
            students.signature.startYear = 2017;

            Console.ReadLine();
        }
    }
}