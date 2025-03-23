namespace Assignment4 {
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PaymentStrategyFactory();
            var paymentService = new PaymentService(factory);

            paymentService.ProcessPayment("creditcard", 100.50);
            paymentService.ProcessPayment("paypal", 75.25);
            paymentService.ProcessPayment("crypto", 200.00);
        }
    }
}