using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
   
    abstract class Account : IAccount
    {
        private string accNo;
        private string accName;
        private string pin;
        private bool active;
        private DateTime dtOfOpening;
        private double balance;

        public Account()
        {
            
        }
        public Account(string accNo,string accName, string pin, double balance)
        {
            this.accNo = accNo;
            this.accName = accName;
            this.pin = pin;
            this.balance = balance;
        }
        public void setAccNo(string no)
        {
            accNo = no;
        }

        public string getAccNo()
        {
            return accNo;
        }

        public void setAccName(string accName)
        {
            this.accName = accName;
        }

        public string getAccName()
        {
            return accName;
        }

        public void setPin(string no)
        {
            pin = no;
        }

        public string getPin()
        {
            return pin;
        }

        public void setActive(bool no)
        {
            active = no;
        }

        public bool getActive()
        {
            return active;
        }

        public void setDate(DateTime no)
        {
            dtOfOpening = no;
        }

        public DateTime getDate()
        {
            return dtOfOpening;
        }

        public void setBalance(double no)
        {
            balance = no;
        }

        public double getBalance()
        {
            return balance;
        }

        public bool open()
        {
            bool flag = false;
            dtOfOpening = DateTime.Now;
            setActive(true);
            flag = true;
            return true;
        }

        public bool close()
        {
            bool flag = false;
            dtOfOpening = DateTime.Now;
            setActive(false);
            setBalance(0);
            flag = true;
            return true; 
        }

        public abstract AccountType getType();
       
    }
}
