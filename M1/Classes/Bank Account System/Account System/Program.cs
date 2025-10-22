using AccountSystem;
Console.WriteLine("----------Bank Account System----------");

Console.WriteLine("-----Creating New Account-----");
Console.Write("Enter Account Number: ");
string? accountNumber = Console.ReadLine();
BankAccount account1 = new(accountNumber);
Console.Write("Enter Account Name: ");
account1.AccountHolder = Console.ReadLine();

Console.WriteLine("-----Creating New Account-----");
Console.Write("Enter Account Number: ");
accountNumber = Console.ReadLine();
Console.Write("Enter initial account balance: ");
decimal initialBalance = decimal.TryParse(Console.ReadLine(), out decimal value) ? value : 0m;
BankAccount account2 = new(accountNumber,initialBalance);
Console.Write("Enter Account Name: ");
account2.AccountHolder = Console.ReadLine();

account1.Deposit(1000m);
account1.Deposit(1000m);
account1.Withdraw(3000m);

account2.Deposit(1000m);
account2.Deposit(1000m);
account2.Withdraw(2000m);

account1.DisplayInfo();
account2.DisplayInfo();

Console.WriteLine($"Total Transactions over all accounts: {BankAccount.TotalTransactions}");
Console.ReadKey();