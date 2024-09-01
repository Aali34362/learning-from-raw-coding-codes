namespace ACIDProperty;

public class BankAccount(int accountId, decimal initialBalance)
{
    public int AccountId { get; private set; } = accountId;
    public decimal Balance { get; private set; } = initialBalance;
    private decimal _backupBalance;
    private object _lock = new object();

    public void Backup()
    {
        _backupBalance = Balance;
    }
    public void Rollback()
    {
        Balance = _backupBalance;
    }
    public void Withdraw(decimal amount)
    {
        lock (_lock)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }
    }

    public void Deposit(decimal amount)
    {
        lock (_lock)
        {
            Balance += amount;
        }
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public void PrintBalance()
    {
        Console.WriteLine($"Account {AccountId} balance: {Balance:C}");
    }
}
