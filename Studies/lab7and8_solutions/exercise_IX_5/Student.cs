using System;
using System.Text;

    class Student : Person
    {
        private const byte GRADES_COUNT = 5;
        private float?[] grades;
        
        // hiding of surname
        public new string surname;

        public Student()
        {
            Console.WriteLine("Create default student");
        }

        public Student(string name, string surname, bool female)
            : base(name, surname, female, null, null)
        {
            grades = new float?[GRADES_COUNT];

            // surname is inherited from Person class and hidden in Student class    
            // I overwrite value of surname (it removes previous value)
            // previous value (from Person class) exists
            // and is accessible when the object will be treated as Person
            this.surname = "YYY";  
        }               


        public new void Show()
        {
            Console.WriteLine("Student: {0} {1}", name, surname);
        }

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

        public override object Clone()
        {
            object copy = new Student(name, surname, female);
            return copy;
        }

    // IX.5
    public override void answer(string s)
    {
        Console.WriteLine(name + " " + surname 
            + " says: thank you, I got " + s
            + ", but I can't because of my exam");
    }

}
