using OOP_GB.Enums;

namespace OOP_GB
{
    public sealed class BankAccount
    {
        private readonly BankAccountType _type = BankAccountType.Checking;

        private string _number = "00000000000000000000";

        private decimal _balance;


        /// <returns>Return 'true', if operation completed successfully</returns>
        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if(_balance - amount >= 0)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public string GetInfo()
        {
            return $"Account numbet: {_number}\n" +
                    $"Type: {_type}\n" +
                    $"Balance: {_balance}";
                     
        }
    }
}
