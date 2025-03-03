using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    //public class PaymentProcessor
    //{
    //    IPaymentGateway gateway = null;
    //    // Dokonywanie płatności
    //    // Wywołanie metody CreatePaymentGateway(...) zwraca nam obiekt utworzony
    //    // w zależności od wyboru rodzaju płatności przez klienta
    //    public void MakePayment(EPaymentMethod method, Product product)
    //    {
    //        PaymentGatewayFactory2 factory = new PaymentGatewayFactory2();
    //        this.gateway = factory.CreatePaymentGateway(method, product);
    //        // w przkładzie, który został przygotowany nie została przygotowana metoda do "obsługi"
    //        // płatności przez PayPal - w tym miejscu wyskoczy nam błąd. Aby tego uniknać należy
    //        // przygotować metodę jak poniżej...
    //        // oraz w klasie PaymentGatewayFactory2, metodzie: CreatePaymentGateway
    //        // dodać kod - > gateway = new Paypal();
    //        this.gateway.MakePayment(product);
    //    }
    //}

    public class PaymentProcessor
    {
        private readonly PaymentGatewayFactory _gatewayFactory;

        public PaymentProcessor(PaymentGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }

        public void MakePayment(EPaymentMethod method, Product product)
        {
            var gateway = _gatewayFactory.CreatePaymentGateway(method);
            Console.WriteLine("Przetwarzanie płatności dla klienta o ID: {0}", product.CustomerId);
            gateway.MakePayment(product);
        }
    }
}
