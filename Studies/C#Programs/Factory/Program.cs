using Factory;
namespace BankExampleGoF;

class Program
{
    //static void Main(string[] args)
    //{
    //    // Tworzenie instancji klasy w której znajduje się metoda do dokonania płatności
    //    PaymentProcessor pre = new PaymentProcessor();
    //    // Definiujemy produkt - to jest tylko przykład
    //    Product prod = new Product();
    //    //prod.Name = "Audi RS6";
    //    //prod.Price = 560000;
    //    //prod.Description = "Bardzo szybkie rodzinne kombi";
    //    //prezkjaz zamiast całych obviektów tylko ID i pobierz w jakims servisie zamisats price, desacirption 
    //    prod.Id = 1;

    //    prod.CustomerId = 12345;
    //    // Dokonujemy płatności pierwszym sposobem.
    //    // W razie problemów z analizą kodu zachęcam do ponownego zapoznania się z artykułem
    //    // oraz dokładnego prześledzenia krok po kroku co dzieje się w kodzie
    //    pre.MakePayment(EPaymentMethod.PAYPAL, prod);
    //    Console.ReadKey();
    //    // Wynik działania programu
    //    // Pierwszy rodzaj platnosci za Audi RS6, kwota 560000
    //}
    static void Main(string[] args)
    {
        // Ustawienie DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IProductService, ProductService>()  // Rejestracja serwisu pobierania danych o produkcie
            .AddSingleton<PaymentProcessor>()  // Rejestracja procesora płatności
            .BuildServiceProvider();

        // Uzyskujemy dostęp do PaymentProcessor z wstrzykniętym IProductService
        var pre = serviceProvider.GetService<PaymentProcessor>();

        // Tworzymy produkt z tylko identyfikatorem
        Product prod = new Product { Id = 1, CustomerId = 12345 };

        // Dokonujemy płatności pierwszym sposobem
        pre.MakePayment(EPaymentMethod.PAYPAL, prod);
        Console.ReadKey();
    }
}
//Install-Package Microsoft.Extensions.DependencyInjection



//using System;
//namespace BankExampleGoF
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Tworzenie instancji klasy w której znajduje się metoda do dokonania płatności
//            PaymentProcessor pre = new PaymentProcessor();
//            // Definiujemy produkt - to jest tylko przykład
//            Product prod = new Product();
//            prod.Name = "Audi RS6";
//            prod.Price = 560000;
//            prod.Description = "Bardzo szybkie rodzinne kombi";
//            // Dokonujemy płatności pierwszym sposobem.
//            // W razie problemów z analizą kodu zachęcam do ponownego zapoznania się z artykułem
//            // oraz dokładnego prześledzenia krok po kroku co dzieje się w kodzie
//            pre.MakePayment(EPaymentMethod.PAYPAL, prod);
//            Console.ReadKey();
//            // Wynik działania programu
//            // Pierwszy rodzaj platnosci za Audi RS6, kwota 560000
//        }
//    }
//    public enum EPaymentMethod
//    {
//        BANK_ONE,
//        BANK_TWO,
//        PAYPAL,
//        PRZELEWY24
//    }
//    public class Product
//    {
//        public string Name { get; set; }
//        public string Description { get; set; }
//        public decimal Price { get; set; }
//    }
//    public interface IPaymentGateway
//    {
//        void MakePayment(Product product);
//    }
//    public class BankOne : IPaymentGateway
//    {
//        public void MakePayment(Product product)
//        {
//            // Metoda to pozwala na dokonanie płatności za pomocą pierwszego sposobu
//            Console.WriteLine("Pierwszy rodzaj płatności za {0}, kwota {1}", product.Name, product.Price);
//        }
//    }
//    public class BankTwo : IPaymentGateway
//    {
//        public void MakePayment(Product product)
//        {
//            // Metoda to pozwala na dokonanie płatności za pomocą drugiego sposobu
//            Console.WriteLine("Drugi rodzaj płatności za {0}, kwota {1}", product.Name, product.Price);
//        }
//    }
//    // W klasie zdefiniowana jest logika obsługi starego rodzaju płatności
//    public class PaymentGatewayFactory
//    {
//        public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method, Product prod)
//        {
//            IPaymentGateway gateway = null;
//            switch (method)
//            {
//                case EPaymentMethod.BANK_ONE:
//                    gateway = new BankOne();
//                    break;
//                case EPaymentMethod.BANK_TWO:
//                    break;
//                    gateway = new BankTwo();
//                default:
//                    break;
//            }
//            return gateway;
//        }
//    }
//    public class PaymentGatewayFactory2 : PaymentGatewayFactory
//    {
//        public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method, Product prod)
//        {
//            IPaymentGateway gateway = null;
//            switch (method)
//            {
//                case EPaymentMethod.PAYPAL:
//                    // obsługa przelewów przez system Paypal
//                    break;
//                case EPaymentMethod.PRZELEWY24:
//                    // obsługa przelewów przez system Przelewy24
//                    break;
//                default:
//                    // jeżeli nie reazlizujemy nowego sposobu płątności wywołujemy metodę bazową,
//                    // która obsługuje pozostałe rodzaje płatności
//                    base.CreatePaymentGateway(method, prod);
//                    break;
//            }
//            return gateway;
//        }
//    }
//    public class PaymentProcessor
//    {
//        IPaymentGateway gateway = null;
//        // Dokonywanie płatności
//        // Wywołanie metody CreatePaymentGateway(...) zwraca nam obiekt utworzony
//        // w zależności od wyboru rodzaju płatności przez klienta
//        public void MakePayment(EPaymentMethod method, Product product)
//        {
//            PaymentGatewayFactory2 factory = new PaymentGatewayFactory2();
//            this.gateway = factory.CreatePaymentGateway(method, product);
//            // w przkładzie, który został przygotowany nie została przygotowana metoda do "obsługi"
//            // płatności przez PayPal - w tym miejscu wyskoczy nam błąd. Aby tego uniknać należy
//            // przygotować metodę jak poniżej...
//            // oraz w klasie PaymentGatewayFactory2, metodzie: CreatePaymentGateway
//            // dodać kod - > gateway = new Paypal();
//            this.gateway.MakePayment(product);
//        }
//    }
//    public class Paypal : IPaymentGateway
//    {
//        public void MakePayment(Product product)
//        {
//            // Metoda to pozwala na dokonanie płatności za pomocą trzeciego sposobu
//            Console.WriteLine("Trzeci rodzaj płatności (PayPal) za {0}, kwota {1}", product.Name, product.Price);
//        }
//    }
//}