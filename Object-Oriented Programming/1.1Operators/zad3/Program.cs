int a = 0;
int b = 1;
int c = 2;

var tautology1 = a == b || a != b ;
Console.WriteLine(tautology1);
var tautology2 = !(a > b && a <= b);
Console.WriteLine(tautology2);
var tautology3 = (a != c && b != c) == (a != c || b != c);
Console.WriteLine(tautology3);
