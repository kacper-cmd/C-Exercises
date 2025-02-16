using System;

namespace classes_1_3
{
    partial class Group
    {
        // METHODS, PASSING PARAMETERS BY REFERENCE        
        // a method searching given surname in a group
        // the method (a) calculates how many persons in the group have given surname
        // and (b) searches first occurence of person with that surname
        // (a) is returned as a result, (b) is returned as a parameter

        // the parameter 'position' passed by reference
        //public int Find(string surnameToFind, ref int position){ 
        // like previous, but without need of initialization of 'position'
        //public int Find(string surnameToFind, out int position){ 
        // parameters passed by value
        public int Find(string surnameToFind, int position)
        {
            
            int result = 0, i = 0;
            position = -1;
            foreach (Person member in members)
                if (member != null)
                {
                    if (member.surname == surnameToFind)
                    {
                        result++;
                        if (position == -1) position = i;
                    }
                    i++;
                }
            return result;
        }


        // METHOD WITH ANY NUMBER OF PARAMETERS
        // below method adds any number of persons to front of the group
        // (without checking if existing members of group are overwrite)        
        public void add2(params Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
                if (members.Length > i) members[i] = persons[i];
        }
    }
}
