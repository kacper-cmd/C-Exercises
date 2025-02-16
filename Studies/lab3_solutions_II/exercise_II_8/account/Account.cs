using System;

namespace account
{
    class Account
    {
        string number;
        DateTime createOn;
        string owner;
        Transaction[][] transactions;

        public Account(string number, string owner, DateTime cd)
        {
            this.number = number;
            this.owner = owner;
            createOn = cd;
            transactions = new Transaction[2][] { new Transaction[500], new Transaction[1000] };   
        }

        public void Print()
        {
            //Console.WriteLine("Account number: {0}, created {1} \nOwner is: {2}", number, 
            //    createOn, owner);
            Console.WriteLine($"Account number: {number}, " +
                $"created {createOn}\nOwner is: {owner} ");
        }

        public override string ToString()
        {
            return $"Account number: {number}, created {createOn}\nOwner is: {owner} ";
        }
    }
}
