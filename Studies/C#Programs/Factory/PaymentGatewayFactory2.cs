using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class PaymentGatewayFactory2 : PaymentGatewayFactory
    {
        public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method, Product prod)
        {
            IPaymentGateway gateway = null;
            switch (method)
            {
                case EPaymentMethod.PAYPAL:
                    // obsługa przelewów przez system Paypal
                    break;
                case EPaymentMethod.PRZELEWY24:
                    // obsługa przelewów przez system Przelewy24
                    break;
                default:
                    // jeżeli nie reazlizujemy nowego sposobu płątności wywołujemy metodę bazową,
                    // która obsługuje pozostałe rodzaje płatności
                    base.CreatePaymentGateway(method, prod);
                    break;
            }
            return gateway;
        }
    }
}
