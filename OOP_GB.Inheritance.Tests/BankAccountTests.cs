using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOP_GB.Inheritance.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void OperatorEqual()
        {
            BankAccount account1 = new BankAccount(BankAccountType.Checking, 1000);
            BankAccount account2 = new BankAccount(BankAccountType.Checking, 1000);

            bool condotion = account1 == account2;

            Assert.IsTrue(condotion);
        }

        [TestMethod]
        public void OperatorUnequal()
        {
            BankAccount account1 = new BankAccount(BankAccountType.Checking, 999);
            BankAccount account2 = new BankAccount(BankAccountType.Checking, 1000);

            bool condotion = account1 != account2;

            Assert.IsTrue(condotion);
        }
    }
}
