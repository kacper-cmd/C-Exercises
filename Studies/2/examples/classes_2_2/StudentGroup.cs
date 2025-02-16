using System;

namespace classes_2_2
{
    class StudentGroup : Group
    {
        public StudentGroup(int places, string name) : base(places, name){}
        public StudentGroup(string name, params Person[] persons) : base(name, persons) { }

        public void ShowStudentGroup()
        {
            Console.Write("\nStudent group");
            // second usage of base (calling of base class method), here unnecessary
            // because Show() is inherited and StudentGroup class hasn't its own Show() method
            base.Show(); 
        }
    }
}
