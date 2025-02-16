using System;
using static System.Console;

namespace account
{
    class Transaction
    {
        DateTime date;
        string title;
        decimal amount; // negative indicates debit, positive indicates credit

        public Transaction(DateTime date, string title, decimal amount)
        {
            this.date = date;
            this.title = title;
            this.amount = amount;
        }

        public void Print()
        {
            WriteLine($"Transaction made in {date} of title: {title}, {amount:c}");
        }

        public override string ToString()
        {
            return $"Transaction made in: {date} of title: {title}, {amount:c}";
        }
    }    

}
