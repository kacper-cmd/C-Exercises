[Flags]
enum Days
{
    Pn = 1,
    Wt = 2,
    Śr = 4,
    Czw = 8,
    Pt = 16,
    So = 32,
    Nd = 64
}

class Program
{
    static void Main(string[] args)
    {
        Days MyDays = Days.Nd | Days.Pt;
      
        Console.WriteLine(MyDays);

        var sum = (int)MyDays;
        Console.WriteLine(sum);

        Console.Read();
    }
}