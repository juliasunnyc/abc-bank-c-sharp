 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public abstract class transaction
    {
        public virtual double amount { get; set; }
        public virtual string transactionType { get; set; }
        public abstract DateTime transactionDate { get; set; }
      
    }
  
    public class Transaction :transaction
    {
        public  double amt;
        private string transType;
        private DateTime transDate;
        public const string WITHDRAW = "withdraw";
        public const string DEPOSITE = "deposite";
        public const string  TRANSFER =  "transfer" ;

        public override double amount
        {
            get { 
                  return amt;
                 }
            set {
                amount = value;
              }

        }

        public override string transactionType
        {
            get
            {
                return transType;
            }
            set
            {
                transType = value;
            }

        }

        public override  DateTime transactionDate
        {
            get
            {
                return transDate;
            }
            set
            {
                transDate = value;
            }

        }


        public Transaction( double amounts, string type)
        {

            this.amount = amounts;
            this.transactionDate = DateProvider.getInstance().now();
            this.transType = type;
        }

    }
}
