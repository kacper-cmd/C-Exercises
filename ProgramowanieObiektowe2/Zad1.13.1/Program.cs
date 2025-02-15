TimeExample t1 = new TimeExample(1, 59, 59);
TimeExample t2 = new TimeExample(2, 0, 0);

Console.WriteLine(t1); 
Console.WriteLine(t2); 

Console.WriteLine(t1 == t2);
Console.WriteLine(t1 != t2);
Console.WriteLine(t1 < t2);
Console.WriteLine(t1 > t2);

t1++;
Console.WriteLine(t1);

t2--;
Console.WriteLine(t2);
t2--;
Console.WriteLine(t2);
