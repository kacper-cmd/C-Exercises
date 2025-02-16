using System;

namespace invoice
{
    class Invoice
    {
        private DateTime saleDate;
        private string customerName;
        private Sale[] positions;
        private byte firstFreePositionIdx = 0;

        public Invoice(DateTime sD, string c)
        {
            saleDate = sD;
            customerName = c;
            positions = new Sale[20];
        }

        public void addPosition(Sale position)
        {
            positions[firstFreePositionIdx++] = position;
        }
        public void addPosition(string p, int a, decimal sP)
        {
            addPosition(new Sale(p, a, sP));
        }

        public void Print()
        {
            // alternative way to embed values into string
            Console.WriteLine($"Invoice\nDate: {saleDate:dd.MM.yyyy}, " +
                              $"customer: {customerName}");
            Console.WriteLine("Positions:");
            foreach (Sale s in positions) if (s != null) s.Print();
        }
    }
}
