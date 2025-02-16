using System;

namespace classes_2_3
{
    class Person
    {
        protected string name;
        public string surname; // public needed to test it in main()
        short? height;
        float? weight;
        protected bool female;

        // constructor
        public Person(string name, string s, bool female, short? height, float? weight)
        {
            this.name = name;
            surname = s;
            this.height = height;
            this.weight = weight;
            this.female = female;
        }

        // default constructor
        public Person() { }

        // property
        public string Sex
        {
            get { return female ? "female" : "male"; }
            set { female = value == "female" ? true : false; }
        }

        // non-virtual method, can be hidden in subclasses
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight, Sex);
        }

        // virtual method, can be override in subclasses 
        public virtual void Show2()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight, Sex);
        }

    } 
} 
