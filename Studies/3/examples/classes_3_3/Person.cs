using System;

namespace classes_3_3
{
    partial class Person
    {
        protected string name;
        public string surname; // for a while, should be protected
        short? height;
        float? weight;
        protected bool female;

        protected MaritalStatus ms;

        // constructor
        public Person(string name, string s, bool female, short? height, float? weight)
        {
            this.name = name;
            surname = s;
            this.height = height;
            this.weight = weight;
            this.female = female;

            ms = MaritalStatus.Single;
        }

        // default constructor
        public Person() { }

        // property
        public string Sex
        {
            get { return female ? "female" : "male"; }
            set { female = value == "female" ? true : false; }
        }

        // non-virtual method
        // sex info is replaced by marital status info
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight, ms);
        }

        // virtual method 
        // sex info is replaced by marital status info
        public virtual void Show2()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight, ms);
        }

        public void Marriage()
        {
            ms ++;            
            // complete it by passing wife/husband object as a parameter
        }

    } 
} 
