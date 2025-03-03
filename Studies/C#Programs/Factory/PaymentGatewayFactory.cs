using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    //public class PaymentGatewayFactory
    //{
    //    public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method, Product prod)
    //    {
    //        IPaymentGateway gateway = null;
    //        switch (method)
    //        {
    //            case EPaymentMethod.BANK_ONE:
    //                gateway = new BankOne();
    //                break;
    //            case EPaymentMethod.BANK_TWO:
    //                break;
    //                gateway = new BankTwo();
    //            default:
    //                break;
    //        }
    //        return gateway;
    //    }
    //}
    public class PaymentGatewayFactory
    {
        private readonly IProductService _productService;

        public PaymentGatewayFactory(IProductService productService)
        {
            _productService = productService;
        }

        public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method)
        {
            IPaymentGateway gateway = null;
            switch (method)
            {
                case EPaymentMethod.BANK_ONE:
                    gateway = new BankOne(_productService);
                    break;
                case EPaymentMethod.BANK_TWO:
                    gateway = new BankTwo(_productService);
                    break;
                case EPaymentMethod.PAYPAL:
                    gateway = new Paypal(_productService);
                    break;
                default:
                    break;
            }
            return gateway;
        }
    }
}
