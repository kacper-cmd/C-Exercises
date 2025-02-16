using System;

namespace account
{
    class Ex_III_3
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("100200300", 
                new group_person.Person("Jan", "Nowak", 0, 0, false), 
                DateTime.Now);
            //a1.Print();            
            Console.WriteLine(a1);
            Console.WriteLine();

            Transaction t = new Transaction(DateTime.Now, "School fee", -600);
            t.Print();

            // test III.3a
            Console.WriteLine(t);

            // test III.3b
            decimal x = t.Amount;
            Console.WriteLine(x);
            t.Amount = -800;
            Console.WriteLine(t);
            Console.WriteLine();

            // test III.3d & III.3g
            Transaction t2 = new Transaction(DateTime.Now, "Salary", 3600);
            Transaction t3 = new Transaction(DateTime.Now, "Shopping", -900);

            a1.debitAccount(t);
            a1.creditAccount(t2);
            a1.debitAccount(t3);

            a1.Print();
            Console.WriteLine();

            // test III.3e
            Console.WriteLine($"Account balance is: {a1.Balance:c}");
            Console.WriteLine();

            // test III.3f
            Console.WriteLine("Second debit transaction is: {0:c}", a1["debit", 1]);
            Console.WriteLine();
            
            Transaction t4 = new Transaction(DateTime.Now, "Energy fee", -210);
            Transaction t5 = new Transaction(DateTime.Now, "Tax refund", 2430);
            Transaction t6 = new Transaction(DateTime.Now, "Purchase of shoes", -290);            
            a1["debit", 2] = t4;
            a1["debit", 3] = t6;
            a1["credit", 1] = t5;
            a1.Print();

            Console.ReadLine();
        }
    }
}
