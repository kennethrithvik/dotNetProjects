using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    interface IAccount
    {
            void setAccNo(string no);
            string getAccNo();
            void setAccName(string accName);
            string getAccName();
            void setPin(string no);
            string getPin();
            void setActive(bool no);
            bool getActive();
            void setDate(DateTime no);
            DateTime getDate();
            void setBalance(double no);
            double getBalance();
            AccountType getType();
            bool open();

            bool close();

    }
}
