using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            


            Console.ReadKey();
        }
    }


    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds. ");
            }
        }



    }

    // This sealed keyword prevents other classes from inheriting SavingsAccount class
    // Why use the "sealed" keyword?

    // Design Integrity:
    // Sealing a class ensures that its design is final and cannot be altered through inheritance.
    // This is important when you want to enforce specific behavior and prevent modifications
    // that could compromise the intended design.

    // Example:
    // In a banking application, a SavingsAccount class might contain specific withdrawal rules.
    // Marking the class as sealed prevents other classes from inheriting from it and overriding
    // those rules.

    // Why use the "sealed" keyword?

    // Security:
    // Preventing further inheritance can enhance security by avoiding unintended
    // behavior or misuse.
    // By sealing a class, you ensure that critical functionality remains
    // consistent and secure.

    // Example:
    // In a banking application, sealing the SavingsAccount class ensures that
    // no unauthorized or accidental changes can be made to how withdrawals
    // are processed, maintaining the security of account operations.

    // Why use the "sealed" keyword?

    // Performance:
    // Sealed classes can sometimes lead to performance optimizations.
    // The runtime doesn't need to check for method overrides in derived classes,
    // which can result in faster execution.

    // Example:
    // In high-performance applications, sealing classes that are not meant to be
    // extended can reduce the overhead of virtual method calls and provide
    // slight performance improvements.


    // Preventing Misuse:
    // Sealing a class prevents it from being used as a base class.
    // This is important when the class was not designed with extensibility in mind.
    // It helps avoid potential misuse or errors caused by improper extensions.
    //
    // Example:
    // If SavingsAccount is not intended to be extended with additional account
    // types or behaviors, sealing it ensures developers do not mistakenly try
    // to inherit from it.

    public sealed class SavingsAccount: Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance,) : base(accountNumber, initialBalance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            // Savings account specific withdraw logic, e.g., no ovedrafts allowed
            if (amount <= Balance) 
            { 
                base.Withdraw(amount);
            } else
            {
                Console.WriteLine("Insufficient funds. cannot withdraw from a savings account! ");
            }
        }
    }
}
