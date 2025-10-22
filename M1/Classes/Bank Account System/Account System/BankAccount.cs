namespace AccountSystem;

public class BankAccount
{
    private decimal balance;
    public string? AccountNumber { get; private set; }
    public string? AccountHolder { get; set; }
    public static int TotalTransactions { get; set; } = 0;

    public BankAccount(string? accountNumber) : this(accountNumber,0m)
    {
    }

    public BankAccount(string? accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        balance = initialBalance;
        AccountHolder = "";
    }


    public void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"You have succesfully deposited £{amount}");
        TotalTransactions++;
    }

    public void Withdraw(decimal amount)
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient funds!");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawal succesful!");
            TotalTransactions++;
        }
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Current Balance: {balance}");
    }
}