using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
     public abstract class Accounts
     {
         public virtual string AccountNo { get; set;}
         public virtual int AccountType{ get; set;}
         public abstract void Deposit ( double money);
         public abstract void Withdraw (double money);
         public abstract double interestEarned();
         public abstract List<Transaction> transactions();
     }

    public class Account : Accounts
    {
        private string acctNo;
        private int acctType;
        private List<Transaction> trans;
        public const int CHECKING = 0;
        public const int SAVINGS = 1;
        public const int MAXI_SAVINGS = 2;

        public Account(int acctype, string acctNo)
        {
            this.acctType = acctype;
            this.AccountNo = acctNo;
        }
 
        public override string AccountNo
        {
            get
            {
                return acctNo;
            }
            set
            {
                acctNo = value;
            }
        }


        public override int AccountType
        {
            get
            {
                 
              return acctType;
            }
            set
            {
                acctType = value;
            }
        }

        public override List<Transaction> transactions()
        {
            
                return trans;
            
        }


        public override void Deposit(double amount )
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                trans.Add(new Transaction(amount, "deposite"));
            }
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                trans.Add(new Transaction(-amount, "withdraw"));
            }
        }

        public override double interestEarned()
        {
            double amount = sumTransactions();
            switch (acctType)
            {
                case SAVINGS:
                    if (amount <= 1000)
                        return amount * 0.001;
                    else
                        return 1 + (amount - 1000) * 0.002;
                // case SUPER_SAVINGS:
                //     if (amount <= 4000)
                //         return 20;
                //Additional features 
                //interest rate to be 5% if no withdraw in the past 10 days 
                //otherwise 1%
                case MAXI_SAVINGS:
                    /*if (amount <= 1000)
                        return amount * 0.02;
                    if (amount <= 2000)
                        return 20 + (amount - 1000) * 0.05;
                     return 70 + (amount - 2000) * 0.1;
                    default:
                    return amount * 0.001;*/
                    if (checkWithdraw())
                        return amount * 0.01;  
                    else
                        return amount * 0.05;
                 default:
                    return amount * 0.001;
           
            }
 
        }

        //check if there are withdraws within the last 10 days 
        public Boolean checkWithdraw( )
        {
            Boolean rtn = false;
            foreach( Transaction tran in trans)
            {  
                if (DateTime.Compare(tran.transactionDate, DateTime.Now.AddDays(-10)) >0 && tran.transactionType.Equals("withdraw") )
                {
                    rtn = true;
                }
            }
  
            return rtn;
   
        }

        public double sumTransactions()
        {
            return checkIfTransactionsExist(true);
        }

        private double checkIfTransactionsExist(bool checkAll)
        {
            double amount = 0.0;
            foreach (Transaction t in trans)
                amount += t.amount;
            return amount;
        }

        /*public int getAccountType()
        {
            return accountType;
        }*/

    }
}

