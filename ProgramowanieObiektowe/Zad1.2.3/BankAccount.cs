namespace Zad1._2._3;
public class BankAccount
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; private set; }
    public BankAccount(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
   
    public class SavingsAccount
    {
        public SavingsAccount()
        {
          
        }
        public class SplitPayment
        {
            //1000 23
            //2300 
        }
    }
}