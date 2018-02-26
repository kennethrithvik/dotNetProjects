using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class Savings:Account
    {
       

        public Savings() : base()
        {
            setAccNo("SAV" + IdGenerator.generateId());  
        }

        public Savings(string accName, string pin, double balance) : base("SAV" + IdGenerator.generateId(),accName, pin, balance)
        {
            
        }

        public override AccountType getType()
        {
            return AccountType.SAVINGS;
        }

        public override string ToString()
        {
            return "Savings\n accNo=" + getAccNo() + "\n AccountName=" + getAccName() + "\n pin=" + getPin() + "\n Active=" + getActive() +
                "\n Date of Opening=" + getDate() + "\n Balance=" + getBalance() + "\n Account type=" + getType();
        }
       
    }
}
