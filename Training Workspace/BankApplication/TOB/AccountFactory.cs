using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class AccountFactory
    {
        private AccountFactory()
        {
           
        }
        static AccountFactory accref=new AccountFactory();

        static AccountFactory getInstance()
        {
            return accref;
        }

        public static IAccount createAccount(AccountType type)
        {
            IAccount account = null;
            switch (type)
            {
                case AccountType.SAVINGS: account = new Savings();
                    break;
                case AccountType.CURRENT:
                    account = new Current();
                    break;
                case AccountType.CORPORATE: account = new Corporate();
                    break;
            }
            if (account == null)
            {
                throw new InvalidAccountTypeException("Invalid Account Type Exception");
            }
            return account;
        }
    }
}
