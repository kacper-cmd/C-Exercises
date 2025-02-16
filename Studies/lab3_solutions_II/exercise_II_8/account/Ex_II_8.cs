using System;

namespace account
{
    class Ex_II_8
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("100200300", "Jan Kowalski", DateTime.Now);
            a1.Print();
            Console.WriteLine();

            Console.WriteLine(a1);
            Console.WriteLine();

            Transaction t = new Transaction(DateTime.Now, "School fee", -600);
            t.Print();
            Console.ReadLine();
        }
    }
}
