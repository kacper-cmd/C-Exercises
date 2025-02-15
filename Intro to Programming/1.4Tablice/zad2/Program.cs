
Random random = new Random();
var size = 20;
var array = new int[size];
for (var i = 0; i < size; ++i)
{
    array[i] = random.Next(1, 10);
}
Console.WriteLine(string.Join(" ", array));
for (var i = 1; i <= 10; ++i)
{
    var count = array.Count(x => x == i);
    Console.WriteLine($"Ilość elementów równych {i}, wynosi {count}");
}