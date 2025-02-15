
Random random = new Random();
var array1 = new int[2];
var array2 = new int[2];

for (int i = 0; i < array1.Length; i++)
{
    array1[i] = random.Next(10);
    array2[i] = random.Next(10);
}

Console.Write("First array: ");
Console.WriteLine(string.Join(" ", array1));

Console.Write("Second array: ");
Console.WriteLine(string.Join(" ", array2));

var array3 = array1.Concat(array2).ToArray();

Console.Write("Third array: ");
Console.WriteLine(string.Join(" ", array3));