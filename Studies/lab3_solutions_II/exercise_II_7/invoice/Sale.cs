using System;

namespace invoice
{
    class Sale
    {
        private string productName;
        private int amount;
        private decimal salePrice;

        public Sale(string pName, int a, decimal sP)
        {
            amount = a;
            salePrice = sP;
            productName = pName;
        }

        public void Print()
        {
            //Console.WriteLine("Sale: {0} {1} in price {2:c}, total {3:c} "
            //                , amount, productName, salePrice, amount * salePrice);
            // or
            Console.WriteLine($"Sale: {amount} {productName} in price {salePrice:c}, " +
                                $"total {amount * salePrice:c} ");
        }
    }
}
