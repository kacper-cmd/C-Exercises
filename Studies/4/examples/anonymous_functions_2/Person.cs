using System;

enum MaritalStatus : byte { Single = 1, Married, Divorced, Widowed };

partial class Person : ICloneable
 {
        protected string name;
        protected string surname; 
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

        // properties
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }

    public string Sex
        {
            get { return female ? "female" : "male"; }
            set { female = value == "female" ? true : false; }
        }

        public short? Height { get => height; set => height = value; }    

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

        public virtual Object Clone()
        // must be virtual because derived classes (Employee, Student) should override it.
        // otherwise, after cloning, they became simple persons
        {
            object copy = new Person(name, surname, female, height, weight);
            return copy;
        }

    // funkcja obsługi zdarzenia zwolania spotkania przez Grupę
    // tę metodę klasa Osoba deleguje do obsługi tego zdarzenia
    // zwróć uwagę na sygnaturę
    public void answer(object whoCalls, EventArgs zd)
    {
        Console.WriteLine(name + " " + surname + " says: I received a call from " + (whoCalls as Group).Name);
    }

} 

