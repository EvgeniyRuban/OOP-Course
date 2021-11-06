using System.Text;

namespace OOP_GB.Inheritance
{
    public sealed class BankAccount
    {
        private static uint _accountCounter;

        private readonly string _number;

        private readonly BankAccountType _type;

        private decimal _balance;


        public BankAccount() : this(BankAccountType.Checking) 
        { 
        }

        public BankAccount(BankAccountType type) : this(type, 0) 
        { 
        }

        public BankAccount(BankAccountType type, decimal balance)
        {
            _number = GenerateAccountNumber((int)++_accountCounter);
            _balance = balance;
            _type = type;
        }


        public static bool operator ==(BankAccount account1, BankAccount account2)
        {
            return account1._balance == account2._balance  
                && account1._type == account2._type;
        }

        public static bool operator !=(BankAccount account1, BankAccount account2)
        {
            return account1._balance != account2._balance  
                || account1._type != account2._type;
        }


        public BankAccountType Type => _type;

        public string Number => _number;

        public decimal Balance => _balance;

        public void Deposit(decimal amount) => _balance += amount;

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

        /// <returns>Return 'true', if operation completed successfully</returns>
        public bool Transfer(BankAccount account, decimal amount)
        {
            if(Withdraw(amount))
            {
                account.Deposit(amount);
                return true;
            }
            return false;
        }

        public bool Equal(BankAccount account) => account == this;

        public override string ToString()
        {
            return $"Account number: {_number}\n" +
                    $"Type: {_type}\n" +
                    $"Balance: {_balance}\n";
        }

        public override bool Equals(object obj) => Equal(obj as BankAccount);

        public override int GetHashCode() =>_number.GetHashCode() + _type.GetHashCode() + _balance.GetHashCode();

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
