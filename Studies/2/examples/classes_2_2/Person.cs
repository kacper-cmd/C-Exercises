using System;

namespace classes_2_2
{
    class Person
    {
        protected string name;
        public string surname; // for a while, should be protected
        short? height;
        float? weight;
        protected bool female;

        // constructor
        public Person(string name, string surname, bool female, short? height, float? weight)
        {
            this.name = name;
            this.surname = surname;
            this.height = height;
            this.weight = weight;
            this.female = female;
        }
        public Person(string n, string s)
        {
            name = n;
            surname = s;
        }
        // default constructor
        public Person() { }

        // property
        public string Sex
        {
            get { return female ? "female" : "male"; }
            set { female = value == "female" ? true : false; }
        }

        // method
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight,
                              female ? "female" : "male");
        }

    }
}
