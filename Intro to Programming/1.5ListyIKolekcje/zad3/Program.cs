using System.Collections;

var numbers = CollectionFrom0To9(10).ToList();

Dictionary<int,int> dictionary = numbers
    .Distinct()
    .ToDictionary(
        x => x, 
        x => numbers.FindAll(a => a == x).Count);

numbers.ForEach(x => Console.Write($" {x}"));
Console.WriteLine();

foreach (var element in dictionary)
{
    Console.WriteLine($"{element.Key}, {element.Value}");
}

var sortedToMaxText = string.Join(
    Environment.NewLine, 
    dictionary
        .OrderBy(x => x.Key)
        .Select(x => $"{x.Key}: {x.Value}"));

Console.WriteLine("Cyfry od najmniejszej do największej: ");
Console.WriteLine(sortedToMaxText);

var sortedToMinText = string.Join(
    Environment.NewLine, 
    dictionary
        .OrderByDescending(x => x.Key)
        .Select(x => $"{x.Key}: {x.Value}"));

Console.WriteLine("Cyfry od największej do najmniejszej: ");
Console.WriteLine(sortedToMinText);

var sortedByCountText = string.Join(
    Environment.NewLine,
    dictionary
        .OrderByDescending(x => x.Value)
        .Select(x => $"{x.Key}: {x.Value}"));

Console.WriteLine("Ilości wystąpień od największej do najmniejszej: ");
Console.WriteLine(sortedByCountText);

static IEnumerable<int> CollectionFrom0To9(int size)
{
    Random r = new Random();
    for (int i = 0; i < size; i++)
    {
        yield return r.Next(9);
    }
} 