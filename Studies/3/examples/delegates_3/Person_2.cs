using System;

    partial class Person : ICloneable // this interface forces to define Clone() method
    {        
        // this method returns number, in pair, 1 or 2, of person, which is first in some order
        // (here in surname alphabetical order)
        public static byte whoFirstBySurname(Person p1, Person p2)
        {
            if (p1.surname == null) return 1;
            if (p2.surname == null) return 2;
            if (p1.surname.CompareTo(p2.surname) > 0) return 1; else return 2;
        }

        // metoda interfejsu ICloneable realizująca tzw. kopiowanie głębokie

        public virtual object Clone()       
        // this method should be virtual, otherwise, objects of subclasses of Person (e.g. Student)
        // after cloning will be just persons
        {
            object copy = new Person(name, surname, female, height, weight);
            return copy;
        }

       
        
        // the method to be a "callback" for notification of a group       
        public void answer(string s)
        {
            Console.WriteLine(name + " " + surname + " says: thank you, I got " + s);
        }


}

