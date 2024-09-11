// Banking System Assignment

// class: SavingAccount
// 2 properties: AccountNumber, InitialBalance
// Method: SavingAccount(), Deposit(), CalculateInterest()

// class: CurrentAccount
// 2 properties: AccountNumber, InitialBalance
// Method: SavingAccount(), Deposit(), CalculateInterest()


abstract public class BankAccount
{
  private string? _accountNumber;
  private double _balance;
  public string? AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }
  public double Balance { get { return _balance; } set { _balance = value; } }
  public BankAccount(string _accountNumber, double _balance)
  {
    AccountNumber = _accountNumber;
    Balance = _balance;
  }

  public virtual void Deposit(double amount)
  {
    Balance += amount;
  }
  public void CalculateInterest(double interestRate)
  {
    double interest = Balance * (interestRate / 100);
    Deposit(interest);
  }

  public abstract void PrintAccountInfo();

}
public class SavingAccount : BankAccount
{
  public SavingAccount(string _accountNumber, double _balance) : base(_accountNumber, _balance) { }
  // BankAccount => Deposit(), CalculateInterest()

  public override void PrintAccountInfo()
  {
    Console.WriteLine($"Saving Account Balance : {Balance}");
  }
}

public class CurrentAccount : BankAccount
{
  public CurrentAccount(string _accountNumber, double _balance) : base(_accountNumber, _balance) { }
  // BankAccount => Deposit(), CalculateInterest()
  public override void PrintAccountInfo()
  {
    Console.WriteLine($"Cuurent Account Balance : {Balance}");
  }
}

class Program
{
  static void Main(string[] args)
  {
    SavingAccount savingAccount = new SavingAccount("SA101", 5000);
    CurrentAccount currentAccount = new CurrentAccount("CA101", 3000);

    savingAccount.Deposit(5000);
    savingAccount.Deposit(2000); // 12000
    currentAccount.Deposit(2000); // 12000
    savingAccount.CalculateInterest(5);

    savingAccount.PrintAccountInfo();
    currentAccount.PrintAccountInfo();

    BankAccount[] bankAccounts = { new SavingAccount("SA101", 5000), new CurrentAccount("CA101", 3000) };

    foreach (BankAccount bankAccount in bankAccounts)
    {
      bankAccount.PrintAccountInfo();
    }

  }
}