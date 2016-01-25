
       using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public abstract class customer
    {
        public virtual String Name { get; set; }
        public abstract List<Account> Accounts();
        public abstract void transfer(double amount, Account from, Account to);
        public abstract Customer openAccount(Account account);
        public abstract String getStatement();
  
    }

    public class Customer : customer
    {
        private String name;
        private List<Account> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public override String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public override List<Account> Accounts()
        {

            return accounts;
           
        }


       //Add additional features 
        //A customer can transfer between their accounts
        public override void transfer ( double amount, Account from, Account to)
        {
             
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            from.Withdraw(amount);
            to.Deposit(amount);
    
        }

 
        public override Customer openAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }

        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Accounts a in accounts)
                total += a.interestEarned();
            return total;
        }

 
        /*******************************
         * This method gets a statement
         *********************************/
        public override String getStatement()
        {
            //JIRA-123 Change by Joe Bloggs 29/7/1988 start
            String statement = null; //reset statement to null here
            //JIRA-123 Change by Joe Bloggs 29/7/1988 end
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (Account a in accounts)
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + toDollars(total);
            return statement;
        }

        private String statementForAccount(Account a)
        {
            String s = "";

            //Translate to pretty account type
            switch (a.AccountType)
            {
                case Account.CHECKING:
                    s += "Checking Account\n";
                    break;
                case Account.SAVINGS:
                    s += "Savings Account\n";
                    break;
                case Account.MAXI_SAVINGS:
                    s += "Maxi Savings Account\n";
                    break;
            }

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in a.transactions())
            {
               //s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + toDollars(t.amount) + "\n";
                s += "  " + t.transactionType + " " + toDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + toDollars(total);
            return s;
        }

        private String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }
    }
}
