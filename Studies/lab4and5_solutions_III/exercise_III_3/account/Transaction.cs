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
            this.Amount = amount;
        }

        // III.3b
        public decimal Amount { get => amount; set => amount = value; }
        /*
        public decimal Amount { 
            get { return amount; }
            set { amount = value; } 
        } 
        */

        public void Print()
        {
            WriteLine($"Transaction made in {date} of title: {title}, {Amount:c}");
        }

        // III.3a
        public override string ToString()
        {
            return $"Transaction made in: {date} of title: {title}, {Amount:c}";
        }
        
    }    

}
