using System;
using OOP_GB.Enums;

namespace OOP_GB
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount testAccount = new BankAccount(BankAccountType.Checking, 10000);
            decimal transactionSize = 999.99M;
            Console.WriteLine("Init state:\n");
            Console.WriteLine(testAccount.GetInfo());
            do
            {
                Console.WriteLine($"Transaction: {transactionSize}");
                Console.WriteLine($"Balance: {testAccount.Balance}\n");
            }
            while (testAccount.Withdraw(transactionSize));
            Console.ReadKey();
        }
    }
}
