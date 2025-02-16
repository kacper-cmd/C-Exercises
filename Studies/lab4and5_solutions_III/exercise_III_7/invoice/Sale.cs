using System;
using product;

namespace invoice
{
    class Sale
    {
        // III.7a
        //Product product; // class field
        public Product product { get; set; } // class autoproperty
        //int amount;
        public int amount { get; set; }
        //decimal salePrice;
        public decimal salePrice { get; set; }

        public Sale(Product product, int amount, decimal salePrice)
        {
            this.product = product;
            this.amount = amount;
            this.salePrice = salePrice;
        }

        public void print()
        {
            Console.WriteLine("Sale position: {0}, {1} for {2:c}", product, amount, salePrice);
        }

    }
}
