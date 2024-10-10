namespace Adapter.GPTExample;

// Adapter class
public class PayPalAdapter : IPaymentProcessor
{
    private readonly PayPalPayment _payPalPayment;
    public PayPalAdapter(PayPalPayment payPalPayment)
    {
        _payPalPayment = payPalPayment;
    }
    public void ProcessPayment(decimal amount)
    {
        _payPalPayment.MakePayment(amount); // Translates the request
    }
}
