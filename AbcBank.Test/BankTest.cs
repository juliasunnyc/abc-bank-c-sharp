 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AbcBank.Test
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void customerSummary()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.openAccount(new Account(Account.CHECKING, "1234568"));
            bank.addCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.customerSummary());
        }

        [Test]
        public void checkingAccount()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.CHECKING, "1234569" );
            Customer bill = new Customer("Bill").openAccount(checkingAccount);
            bank.addCustomer(bill);

            checkingAccount.Deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void savings_account()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.SAVINGS, "1234564");
            bank.addCustomer(new Customer("Bill").openAccount(checkingAccount));

            checkingAccount.Deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void maxi_savings_account()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.MAXI_SAVINGS,"1234562");
            bank.addCustomer(new Customer("Bill").openAccount(checkingAccount));

            checkingAccount.Deposit(3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

    }
}

