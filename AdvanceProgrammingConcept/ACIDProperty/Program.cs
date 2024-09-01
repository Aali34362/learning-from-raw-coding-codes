using ACIDProperty;

Mutex _mutex = new Mutex();
var account1 = new BankAccount(1, 5000);
var account2 = new BankAccount(2, 2000);

account1.PrintBalance();
account2.PrintBalance();

var bankTransferService = new BankTransferService();

// Transfer 500 from account1 to account2
bankTransferService.Transfer(account1, account2, 500);

account1.PrintBalance();
account2.PrintBalance();

// Transfer 1500 from account1 to account2 (will fail due to transfer limit)
bankTransferService.Transfer(account1, account2, 1500);

account1.PrintBalance();
account2.PrintBalance();

Console.WriteLine();

// Starting multiple threads to simulate concurrent transactions
Thread t1 = new Thread(() => ExecuteTransfer(bankTransferService, account1, account2, 500));
Thread t2 = new Thread(() => ExecuteTransfer(bankTransferService, account2, account1, 200));
Thread t3 = new Thread(() => ExecuteTransfer(bankTransferService, account1, account2, 1500));

t1.Start();
t2.Start();
t3.Start();

t1.Join();
t2.Join();
t3.Join();

account1.PrintBalance();
account2.PrintBalance();

void ExecuteTransfer(BankTransferService service, BankAccount fromAccount, BankAccount toAccount, decimal amount)
{
    _mutex.WaitOne();
    try
    {
        service.Transfer(fromAccount, toAccount, amount);
    }
    finally
    {
        _mutex.ReleaseMutex();
    }
}