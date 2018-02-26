using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class Corporate:Account
    {
        public Corporate() : base()
        {
            setAccNo("COR" + IdGenerator.generateId());  
        }

        public Corporate(string accName, string pin,double balance)
            : base("COR" + IdGenerator.generateId(),accName, pin,balance)
        {
            
            
        }

       
        public override AccountType getType()
        {
            return AccountType.CORPORATE;
        }

        public override string ToString()
        {
            return "Corporate \n accNo=" + getAccNo() + "\n AccountName=" + getAccName() + "\n pin=" + getPin() + "\n Active=" + getActive() +
                "\n Date of Opening=" + getDate() + "\n Balance=" + getBalance() + "\n Account type=" + getType();
        }

    }
}
