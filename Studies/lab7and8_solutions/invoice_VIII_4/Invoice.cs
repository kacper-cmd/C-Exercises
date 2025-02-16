using System;
using group_person;
using product;

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

        public decimal Total
        {
            get
            {
                decimal result = 0;
                foreach (Sale s in salePositions)
                    //if(s != null) result += s.salePrice * s.amount;
                    result += s?.salePrice * s?.amount ?? 0;
                return result;
            }
        }

        public object this[int i, string feature]
        {
            get
            {
                switch (feature)
                {
                    case "product": return salePositions[i].product;
                    case "amount": return salePositions[i].amount;
                    case "salePrice": return salePositions[i].salePrice;
                    default: return null;
                }
            }
            set
            {
                switch (feature)
                {
                    // by the way three techniques of conversion
                    case "product": salePositions[i].product = value as Product; break;
                    case "amount": salePositions[i].amount = (int)value; break;
                    case "price": salePositions[i].salePrice = Convert.ToDecimal(value); break;
                }
            }
        }

        // VIII.4a
        public static explicit operator decimal(Invoice i)
        {
            return i.Total;
        }

        // VIII.4b
        public static implicit operator Invoice(Product[] products)
        {
            Invoice result = new Invoice(DateTime.Today, null);
            foreach (Product p in products)
                result.addPosition(new Sale(p, 1, p.RetailPrice));
            return result;
        }

    }

}
