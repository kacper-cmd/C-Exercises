using System;

namespace group_person
{
    public class Person
    {
        protected string name;
        protected string surname; // for a while, should be protected
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

        // IV.4
        public string phoneNr; // public for test
        public Person(string n, string s, string phNr)
            : this(n, s)
        {
            phoneNr = phNr;
        }
        public Person(Person p) : this(p.name, p.surname, p.phoneNr) { }

        public override string ToString()
        {
            return $"{name} {surname}, private phone: {phoneNr}";
        }

    }
}
