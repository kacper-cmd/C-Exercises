using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class BankTwo : IPaymentGateway
    {
        private readonly IProductService _productService;

        public BankTwo(IProductService productService)
        {
            _productService = productService;
        }
        public void MakePayment(Product product)
        {
            // Metoda to pozwala na dokonanie płatności za pomocą drugiego sposobu
            // Console.WriteLine("Drugi rodzaj płatności za {0}, kwota {1}", product.Name, product.Price);
            var prodDetails = _productService.GetProductDetails(product.Id);
            Console.WriteLine("Drugi rodzaj płatności za {0}, kwota {1}", prodDetails.Name, prodDetails.Price);

        }
    }
}
