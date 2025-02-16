using System;

namespace group_person
{
    // a class derived (inherited) from Person 
    public class Employee : Person
    {
        private string function;
        private DateTime employeeDate;
        
        // default constructor, constructors don't inherit from parent (base) class ...
        public Employee()
        {
            Console.WriteLine("Default employee created");
        }
        
        // ... but can be used in derived class
        // below constructor used constructor from base class (Person)
        // by 'base' keyword
        public Employee(string name, string surname, bool female, string function)
            : base(name, surname, female, null, null)
        {
            this.function = function;
            employeeDate = new DateTime();            
        }
        public Employee(string name, string surname, string function) : base(name, surname) 
        {
            this.function = function;
            employeeDate = new DateTime();
        }

        public int Seniority()
        {
            return DateTime.Now.Year - employeeDate.Year;
        }

    }

}
