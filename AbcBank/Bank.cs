using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{

    public abstract class bank
    {
        public abstract List<Customer> Customers();
        public virtual string bankName { get; set; }
        public abstract void addCustomer(Customer customer);
        public abstract String customerSummary();
        public abstract double totalInterestPaid();     
    }

    public class Bank : bank
    {
        private List<Customer> customers;
        private string bankname;

        public Bank()
       {
            customers = new List<Customer>();
       } 

         public override List<Customer> Customers()
        {    
                return customers;  
        }

         public override string bankName
        {
            get
            {
                return bankname ;
            }
            set
            {
                  bankname= value;
            }
        }

       
        public override void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public override String customerSummary()
        {
            String summary = "Customer Summary";
            foreach (Customer c in customers)
                summary += "\n - " + c.Name + " (" + format(c.getNumberOfAccounts(), "account") + ")";
            return summary;
        }

        //Make sure correct plural of word is created based on the number passed in:
        //If number passed in is 1 just return the word otherwise add an 's' at the end
        private String format(int number, String word)
        {
            return number + " " + (number == 1 ? word : word + "s");
        }

        public override double totalInterestPaid()
        {
            double total = 0;
            foreach (Customer c in customers)
                total += c.totalInterestEarned();
            return total;
        }

       /* public overide String getFirstCustomer()
        {
            try
            {
                customers = null;
                return customers[0].getName();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "Error";
            }
        }*/
    }
}
