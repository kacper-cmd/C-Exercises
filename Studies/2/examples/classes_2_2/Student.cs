using System;

namespace classes_2_2
{
    class Student : Person
    {
        private const byte GRADES_COUNT = 5;
        private float?[] grades;

        public Student()
        {
            Console.WriteLine("Create default student");
        }

        public Student(string name, string surname, bool female)
            : base(name, surname, female, null, null)
        {
            grades = new float?[GRADES_COUNT];         
        }
        public Student(string name, string surname) : base(name, surname) { }

        public float? gradesAverage() {
            float? average = null;
            foreach (float? grade in grades) if (grade != null) average += grade;
            return average / GRADES_COUNT;
        }

    }

}
