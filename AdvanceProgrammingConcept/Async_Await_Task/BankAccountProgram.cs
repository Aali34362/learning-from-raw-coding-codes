namespace Async_Await_Task;
//Lock in Thread
public class BankAccountProgram
{
    private object balanceLock = new object(); // Object used for locking
    private decimal balance;
    public BankAccountProgram(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        lock (balanceLock) // Enter critical section
        {
            if (balance >= amount)
            {
                Console.WriteLine($"Withdrawing {amount}...");
                balance -= amount;
                Console.WriteLine($"Balance after withdrawal: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        } // Exit critical section
    }
}
