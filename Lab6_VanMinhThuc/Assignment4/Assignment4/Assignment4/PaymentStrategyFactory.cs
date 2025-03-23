using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class PaymentStrategyFactory
    {
        public IPaymentStrategy GetPaymentStrategy(string paymentType)
        {
            switch (paymentType.ToLower())
            {
                case "creditcard":
                    return new CreditCardPayment();
                case "paypal":
                    return new PayPalPayment();
                case "crypto":
                    return new CryptoPayment();
                default:
                    throw new ArgumentException("Invalid payment type");
            }
        }
    }
}
