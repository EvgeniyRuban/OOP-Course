using System;

namespace OOP_GB
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount();
            Console.WriteLine(myAccount.GetInfo());
        }
    }
}
