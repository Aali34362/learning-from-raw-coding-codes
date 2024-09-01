using System.Transactions;

namespace ACIDProperty;

public class BankTransferService
{
    private SemaphoreSlim _gate = new SemaphoreSlim(1, 1);
    public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        using (var transaction = new TransactionScope())
        {
            try
            {
                _gate.Wait();

                fromAccount.Backup();
                toAccount.Backup();

                // Atomicity: Withdraw from one account
                fromAccount.Withdraw(amount);
                
                // Simulating a potential error that can occur between operations
                if (amount > 1000)
                {
                    throw new Exception("Transfer limit exceeded.");
                }

                // Atomicity: Deposit to another account
                toAccount.Deposit(amount);

                // Consistency: Commit the transaction if all operations succeed
                transaction.Complete();
            }
            catch (Exception ex)
            {
                fromAccount.Rollback();
                toAccount.Rollback();
                // If any exception occurs, the transaction is automatically rolled back
                Console.WriteLine($"Transaction failed: {ex.Message}");
            }
            finally
            {
                _gate.Release();
            }
        }
    }
}
