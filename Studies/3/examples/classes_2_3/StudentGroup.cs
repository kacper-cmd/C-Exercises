using System;

namespace classes_2_3
{
    class StudentGroup : Group
    {
        public StudentGroup(int places, string name) : base(places, name){}
        public StudentGroup(string name, params Person[] persons) : base(name, persons) { }

        public new void Show()
        {
            Console.Write("\nStudent group");
            base.Show();
        }

        public override void Show2()
        {
            Console.Write("\nStudent group");
            base.Show2();
        }
    }
}
