class Program
{
    static void Main()
    {
        Console.WriteLine("1 - Cyfry były od najmniejszej do największej ");
        Console.WriteLine("2 - Cyfry były od największej do najmniejszej  ");
        Console.WriteLine("3 - Najpierw pokazały się rekordy z największą liczbą wystąpień ");
        Console.WriteLine("Wpisz swoj wybór");
        string choice = Console.ReadLine();
        Dictionary<int, int> data = new Dictionary<int, int>
        {
            { 5, 10 },
            { 1, 20 },
            { 3, 15 },
            { 4, 30 },
            { 6, 45 },
            { 2, 30 }
        };
        foreach (var kvp in data) 
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        switch (choice)
        {
            case "1":
                DisplayNumbersFromSmallestToLargest(data);
                break;
            case "2":
                DisplayNumbersFromLargestToSmallest(data);
                break;
            case "3":
                DisplayNumbersWithGreatestOccurenceNumber(data);
                break;
            default:
                break;
        }
    }
    static void DisplayNumbersFromSmallestToLargest(Dictionary<int, int> data)
    {
        var sortedByKeyAsc = data.OrderBy(kvp => kvp.Key);
        Console.WriteLine("Cyfry od najmniejszej do największej:");
        foreach (var kvp in sortedByKeyAsc)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
    static void DisplayNumbersFromLargestToSmallest(Dictionary<int, int> data)
    {
        var sortedByKeyDesc = data.OrderByDescending(kvp => kvp.Key);
        Console.WriteLine("Cyfry od największej do najmniejszej:");
        foreach (var kvp in sortedByKeyDesc)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
    static void DisplayNumbersWithGreatestOccurenceNumber(Dictionary<int, int> data)
    {
        var sortedByValueDesc = data.OrderByDescending(kvp => kvp.Value);
        Console.WriteLine("Najpierw rekordy z największą liczbą wystąpień:");
        foreach (var kvp in sortedByValueDesc)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}