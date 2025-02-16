using System;

namespace group_person
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

            public Signature(int startYear, string field, char form, string type, char code)
            {
                this.startYear = startYear;
                this.field = field;
                this.form = form;
                this.type = type;
                this.code = code;
            }
        };

        // a field of Signature type
        public Signature signature;

    }
}
