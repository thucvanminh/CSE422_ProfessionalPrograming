using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class PaymentService
    {
        private readonly PaymentStrategyFactory _factory;

        public PaymentService(PaymentStrategyFactory factory)
        {
            _factory = factory;
        }

        public void ProcessPayment(string paymentType, double amount)
        {
            var strategy = _factory.GetPaymentStrategy(paymentType);
            strategy.ProcessPayment(amount);
        }
    }
}
