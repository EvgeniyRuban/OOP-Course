using System;

namespace OOP_GB
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] myAccounts = new BankAccount[20];
            for (int i = 0; i < myAccounts.Length; i++)
            {
                myAccounts[i] = new BankAccount();
                Console.WriteLine(myAccounts[i].GetInfo());
            }
        }
    }
}
