using System;
using group_person;

namespace invoice
{
    class Invoice
    {
        DateTime saleDate;
        Person customer;
        Sale[] salePositions;

        public Invoice(DateTime saleDate, Person customer)
        {
            this.saleDate = saleDate;
            this.customer = customer;
            salePositions = new Sale[20];
        }

        public void addPosition(Sale position)
        {
            int i = 0;
            while (salePositions[i] != null) i++;
            salePositions[i] = position;
        }

        public void print()
        {
            // alternative way to embed values into string
            Console.WriteLine($"Invoice\nDate: {saleDate:dd.MM.yyyy}, customer: {customer}");
            Console.WriteLine("Positions:");
            foreach (Sale s in salePositions) if (s != null) s.print();
        }

    }

}

