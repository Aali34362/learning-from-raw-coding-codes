namespace Adapter.GPTExample;

public class PayPalPayment
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount} dollars.");
    }
}
