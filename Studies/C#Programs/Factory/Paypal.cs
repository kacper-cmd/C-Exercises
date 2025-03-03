using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Paypal : IPaymentGateway
    {
        private readonly IProductService _productService;

        public Paypal(IProductService productService)
        {
            _productService = productService;
        }

        public void MakePayment(Product product)
        {
            // Metoda to pozwala na dokonanie płatności za pomocą trzeciego sposobu
            //Console.WriteLine("Trzeci rodzaj płatności (PayPal) za {0}, kwota {1}", product.Name, product.Price);
            var prodDetails = _productService.GetProductDetails(product.Id);
            Console.WriteLine("Trzeci rodzaj płatności (PayPal) za {0}, kwota {1}", prodDetails.Name, prodDetails.Price);
        }
    }
}
