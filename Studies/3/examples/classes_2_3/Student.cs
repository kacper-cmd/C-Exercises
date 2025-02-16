using System;
using System.Text;

namespace classes_2_3
{
    class Student : Person
    {
        private const byte GRADES_COUNT = 5;
        private float?[] grades;
        
        // hiding of surname from Person (new modifier)
        public new string surname;

        public Student()
        {
            Console.WriteLine("Create default student");
        }

        public Student(string name, string surname, bool female)
            : base(name, surname, female, null, null)
        {
            grades = new float?[GRADES_COUNT];

            // surname is inherited from Person class 
            // but hidden in Student class  by its surname value (here YYY)  
            // Previous value (from Person class) exists
            // and is accessible when the object will be treated as a Person
            // or by expression base.surname
            this.surname = "YYY";  
        }               

        // Show() hides a method from Person, is executed for each object,
        // which has compilation-time (declaration) type Student
        public new void Show()
        {
            Console.WriteLine("Student: {0} {1}", name, surname);
        }

        // Show2() overrides a method from Person, is executed for each object,
        // which has runtime-time (constructor) type is Student
        public override void Show2()
        {
            Console.WriteLine("Student is {0} {1}", name, surname);
        }


        public float? gradesAverage()
        {
            float? average = null;
            foreach (float? grade in grades) if (grade != null) average += grade;
            return average / GRADES_COUNT;
        }

    }

}