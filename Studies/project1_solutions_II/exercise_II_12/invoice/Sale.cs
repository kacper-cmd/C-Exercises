using System;
using product;

namespace invoice
{
    class Sale
    {
        Product product;
        int amount;
        decimal salePrice;

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
