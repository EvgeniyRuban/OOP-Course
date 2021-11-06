using System.Text;
using OOP_GB.Enums;

namespace OOP_GB
{
    public sealed class BankAccount
    {
        private static uint _accountCounter;

        private readonly string _number;

        private readonly BankAccountType _type;

        private decimal _balance;


        public BankAccount() : this(BankAccountType.Checking) { }

        public BankAccount(BankAccountType type) : this(type, 0) { }

        public BankAccount(BankAccountType type, decimal balance)
        {
            _number = GenerateAccountNumber((int)++_accountCounter);
            _balance = balance;
            _type = type;
        }


        public BankAccountType Type => _type;

        public string Number => _number;

        public decimal Balance => _balance;

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

        /// <returns>Return 'true', if operation completed successfully</returns>
        public bool Withdraw(decimal amount)
        {
            if(_balance - amount >= 0)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public bool Transfer(ref BankAccount account, decimal amount)
        {
            if(Withdraw(amount))
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public string GetInfo()
        {
            return $"Account number: {_number}\n" +
                    $"Type: {_type}\n" +
                    $"Balance: {_balance}\n";
        }


        private string GenerateAccountNumber(int value)
        {
            int accountNumberLength = 20;
            int emptySymbolCount = accountNumberLength - value.ToString().Length;
            StringBuilder result = new StringBuilder(accountNumberLength);
            for (int i = 0; i < emptySymbolCount; i++)
            {
                result.Append('0');
            }
            result.Append(value.ToString());

            return result.ToString();
        }
    }
}
