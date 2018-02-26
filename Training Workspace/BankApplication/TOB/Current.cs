using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class Current:Account
    {
       
     
        public Current() : base()
        {
            setAccNo("CUR" + IdGenerator.generateId());  
        }

        public Current(string accName, string pin,double balance)
            : base("CUR" + IdGenerator.generateId(),accName, pin,balance)
        {
            
            
        }

       
        public override AccountType getType()
        {
            return AccountType.CURRENT;
        }

        public override string ToString()
        {
            return "Current \n accNo=" + getAccNo() + "\n AccountName=" + getAccName() + "\n pin=" + getPin() + "\n Active=" + getActive() +
                "\n Date of Opening=" + getDate() + "\n Balance=" + getBalance() + "\n Account type=" + getType();
        }


    }
}
