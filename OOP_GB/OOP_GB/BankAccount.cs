using OOP_GB.Enums;
using System.Text;

namespace OOP_GB
{
    public sealed class BankAccount
    {
        private readonly BankAccountType _type = BankAccountType.Checking;

        private readonly string _number;

        private decimal _balance;

        private static uint _accountCounter;


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
                    $"Balance: {_balance}\n";
        }

        private static string GenerateAccountNumber()
        {
            int accountNumberLength = 20;
            int emptySymbolCount = accountNumberLength - _accountCounter.ToString().Length;
            StringBuilder result = new StringBuilder(accountNumberLength);
            for (int i = 0; i < emptySymbolCount; i++)
                result.Append('0');
            result.Append(_accountCounter.ToString());
            _accountCounter++;
            return result.ToString();
        }
    }
}
