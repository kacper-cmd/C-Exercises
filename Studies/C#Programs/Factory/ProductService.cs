using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ProductService : IProductService
    {
        public ProductDetails GetProductDetails(int productId)
        {
            // Tutaj symulujemy pobieranie danych z bazy danych lub zewnętrznego serwisu
            if (productId == 1)
            {
                return new ProductDetails
                {
                    Name = "Audi RS6",
                    Price = 560000,
                    Description = "Bardzo szybkie rodzinne kombi"
                };
            }

            // Domyślne dane, jeśli produkt nie został znaleziony
            return new ProductDetails
            {
                Name = "Nieznany produkt",
                Price = 0,
                Description = "Brak opisu"
            };
        }
    }

}
