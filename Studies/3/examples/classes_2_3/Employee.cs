using System;

namespace classes_2_3
{
    // a class derived (inheriting) from Person 
    class Employee : Person
    {
        private string function;
        private DateTime employeeDate;
                        
        // hiding of 'surname' field from base class (Person)
        // thus, the object of Employee class has two values of 'surname'
        // depending on type of reference
        public new string surname;              


        // default constructor
        public Employee()
        {
            Console.WriteLine("Default employee created");
        }

        public Employee(string name, string surname, bool female, string function)
            : base(name, surname, female, null, null)
        {
            this.function = function;
            employeeDate = new DateTime();

            // I overwrite value of surname (it removes previous value)
            // this time previous value (from Person class) exists
            // and is accessible when the object will be treated as Person
            this.surname = "XXX"; 
        }


        // Show() hides a method from Person, is executed for each object,
        // which has compilation-time (declaration) type Employee
        // hiding is denoted by 'new' modifier
        public new void Show()
        {
            Console.WriteLine("Employee: {2}, {0} {1}", name, surname, function);
        }
        //*/

        // Show2() overrides a method from Person, is executed for each object,
        // which has runtime-time (constructor) type is Employee
        // overriding is usually denoted by 'override' modifier 
        // (in some cases also 'virtual' or 'abstract' modifiers)
        public override void Show2()
        {
            Console.WriteLine("Employee is {2}, {0} {1}", name, surname, function);
        }

        public int Seniority()
        {
            return DateTime.Now.Year - employeeDate.Year;
        }

    }

}
