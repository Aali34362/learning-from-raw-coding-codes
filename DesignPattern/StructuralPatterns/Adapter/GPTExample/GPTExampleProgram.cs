namespace Adapter.GPTExample;

public static class GPTExampleProgram
{
    public static void GPTExampleMain()
    {
        // Create an instance of the incompatible class
        PayPalPayment payPalPayment = new PayPalPayment();

        // Wrap it in an adapter
        IPaymentProcessor paymentProcessor = new PayPalAdapter(payPalPayment);

        // Client code can now use the adapter as if it were using the unified interface
        paymentProcessor.ProcessPayment(100.00m); // Output: Processing PayPal payment of 100 dollars.
    }
}
