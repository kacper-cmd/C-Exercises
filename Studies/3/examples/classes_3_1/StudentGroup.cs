using System;

namespace classes_3_1
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

        // nested type, a struct defining the group signature
        public struct Signature
        {
            public const string UNIVERSITY = "WSB";
            public int startYear;
            string field; // e.g. computer science, management
            char form; // full-time or part-time
            string type; // masters, engineering, bachelor
            char code; // A, B, C ...
        };

        // a field of Signature type
        public Signature signature;

    }
}
