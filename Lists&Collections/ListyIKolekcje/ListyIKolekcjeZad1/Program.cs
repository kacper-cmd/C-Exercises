using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<bool> boolList = new List<bool> { true, false, false, true, false };

        List<DateTime> dateTimeList = new List<DateTime>
        {
            new DateTime(2024, 7, 5),
            DateTime.Now,
            new DateTime(2024,7, 6),
            new DateTime(2024,7,4)
        };
        
        List<string> stringList = new List<string> { "Hello", "from" ,"GOTOMA", "Software", "house"};

        List<int> intList = new List<int> { 1, 23,21,34,43 };

        List<decimal> decimalList = new List<decimal> { 10.5m, 20.75m,12.32m, 32.43m };
        
        Console.WriteLine("\nDateTime List (zad 2) :");
        foreach (var item in dateTimeList)
        {
            Console.WriteLine(item);
        }
    }
}
