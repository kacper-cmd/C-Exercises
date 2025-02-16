using System;

// declaration a delegate type using to compare two persons
// it's domain is a set of all functions taking two parameters of Person type and returning byte value

delegate byte WhoFirst(Person p1, Person p2);

// members of Group class, which are important for this example (delegates usage)

partial class Group
{    
    // this function sorts members of the group by insertionsort method,
    // a parameter is some method (pass as a delegate type object), which determines a way of comparing persons
    // so in fact a sorting order
    public void insertSort(WhoFirst compare)
    {
        for (int i = 0; i < members.Length && members[i] != null; i++)
        {
            Person tmp = (Person)members[i].Clone(); // to copying we use Clone() method
            int j = i;
            while (j > 0 && compare(members[j - 1], tmp) == 1) // members[j-1] > tmp
            {
                members[j] = (Person)members[j - 1].Clone();
                j--;
            }
            members[j] = (Person)tmp.Clone();
        }
    }


    // a group can notify it's members about sth
    // below declaration of delegate and it's instance, which will aggregate "callback" methods of group members
    public delegate void Notification(string s);
    
    // the class field (delegate instance), responsible for notifications broadcasted by the group
    public Notification notification;

}

