using System;

// Classes: properties and indexers

namespace classes_2_1
{
    class Person
    {        
        string name;
        // below fields have been replaced by autoproperties
        /*
        string surname;
        short height;
        float weight;
        */
        bool female;
        /*
        // a property, which gives a public access to a private field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        // definition of property which transforms boolean value to a string value
        // this property gets public access and changes a data representation
        public string Sex
        {
            get { return female ? "female" : "male"; }
            set { female = value == "female" ? true : false; }
        }

        // a read-only property defines derived attribute
        // that is, a value calculated from data of an object
        public string FullName
        {
            get { return $"{name} {surname}"; } // $"" is an interpolation string
        }
        */
        // other, shorter notation using lambda expression operator (expression bodied properties)
        public string Name { get => name; set => name = value; }
        public string Sex { get => female ? "female" : "male"; 
                            set => female = value == "female" ? true : false; }
        //public string FullName { get => $"{name} {surname}"; }

        //  for getter-only property we can omitt get accessor
        public string FullName => $"{name} {surname}"; 

        // autoproperties, they replace fields and can be public
        public string surname { get; set; }
        public short height { get; set; }
        public float weight { get; set; }


        // constructor
        public Person(string name, string s, short height, float weight, bool female)
        {
            this.name = name;
            surname = s;
            this.height = height;
            this.weight = weight;
            this.female = female;
        }        

        // default constructor
        public Person() {}
               
        
        // definition of an indexer
        // which get access (by an index) to string representation of person data
        public string this[byte i]
        {
            get {
                switch (i)
                {
                    case 0: return name;
                    case 1: return surname;
                    case 2: return height.ToString();
                    case 3: return weight.ToString();
                    case 4: return Sex;
                    default: return null;
                }
            }
        }

        /*
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, "
                              + "{3} kg weight",
                              name, surname, height, weight,
                              female ? "female" : "male");
        }
        */
        
        // Show() method using the indexer
        public void Show()
        {
            Console.WriteLine("Person {4}, {0} {1}, {2} cm height, {3} kg weight",
                              this[0], this[1], this[2], this[3], this[4]);
        }

    } // end of Person class definition
} // end of namespace
