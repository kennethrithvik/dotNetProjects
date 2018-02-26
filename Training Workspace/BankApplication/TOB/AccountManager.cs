using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class AccountManager
    {
        public IAccount createAccount(string accName, string pin, double balance, AccountType type)
        {
            IAccount account = AccountFactory.createAccount(type);
            
            account.setAccName(accName);
            account.setBalance(balance);
            account.setPin(pin);

            return account;

        }

        public bool deposit(IAccount account, double amount, TransactionType type)
        {
            bool flag = false;

            if (!account.getActive())
            {
                throw new InvalidAccountTypeException("Account Inactive");
            }
            else if(type!=TransactionType.DEPOSIT)
            {
                throw new InvalidTransactionTypeException("Invalid Transaction");
            }
            account.setBalance(account.getBalance()+amount);
            flag = true;

            return flag;
        }
        public bool Withdraw(IAccount account, double amount, TransactionType type,string pin)
        {
            bool flag = false;

            if (!account.getActive())
            {
                throw new InvalidAccountTypeException("Account Inactive");
            }
            else if (type != TransactionType.WITHDRAW)
            {
                throw new InvalidTransactionTypeException("Invalid Transaction");
            }
            else if (pin != account.getPin())
            {
                throw new InvalidTransactionTypeException("Incorrect PIN");
            }
            account.setBalance(account.getBalance() - amount);
            flag = true;

            return flag;
        }
    }
}
