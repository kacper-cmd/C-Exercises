using System;
using group_person;

namespace account
{
    class Account
    {
        string number;
        DateTime createOn;
        Person owner; // III.3c replacement of string owner;
        Transaction[][] transactions;
        int debitsCount = 0;

        public Account(string number, Person owner, DateTime cd)
        {
            this.number = number;
            this.owner = owner;
            createOn = cd;
            // [0] - credits (positive), [1] - debits (negative)
            transactions = new Transaction[2][] { new Transaction[500], new Transaction[1000] };   
        }

        public void Print()
        {
            //Console.WriteLine("Account number: {0}, created {1} \nOwner is: {2}", number, 
            //    createOn, owner);
            Console.WriteLine($"Account number: {number}, " +
                $"created {createOn}\nOwner is: {owner} ");

            // III.3g
            if (transactions[0][0] != null)
            {
                Console.WriteLine("Credit transactions:");
                foreach (Transaction credit in transactions[0])
                    Console.Write(
                        (credit ?? null) != null ? "\t" + credit + "\n" : null);
                //if (credit != null) credit.Print();
                //credit?.Print();
            }

            if (debitsCount > 0)
            {
                Console.WriteLine("Debit transactions:");
                foreach (Transaction debit in transactions[1])
                    //if (debit != null) debit.Print();
                    Console.Write(
                        (debit ?? null) != null ? "\t" + debit + "\n" : null);
            }
        }

        // III.3e
        public decimal Balance
        {
            get
            {
                decimal result = 0;
                foreach (Transaction credit in transactions[0])
                    // if(credit != null) result += credit.Amount;
                    // or using ?. and ?? operators
                    result += credit?.Amount ?? 0;
                foreach (Transaction debit in transactions[1])
                    result += debit?.Amount ?? 0;
                return result;
            }
        }

        // III.3f
        public Transaction this[string kind, int idx]
        {
            get
            {
                byte i = 0;
                if (kind == "credit") i = 0;
                else if (kind == "debit") i = 1;
                return transactions[i][idx];
            }            

            set
            {
                byte i = 0;
                if (kind == "credit") i = 0;
                else if (kind == "debit") i = 1;
                transactions[i][idx] = value;
            }

        }

        public override string ToString()
        {
            return $"Account number: {number}, created {createOn}\nOwner is: {owner} ";
        }

        // III.3d
        public void creditAccount(Transaction t)
        {
            // first approach: locally calculating the first free place
            int i = 0;
            while (transactions[0][i] != null) i++;
            transactions[0][i] = t;
        }
        public void debitAccount(Transaction t)
        {
            // second approach: usage of special counter (debitsCount), 
            //defined as class field (or private property)

            transactions[1][debitsCount++] = t;
        }

    }
}
