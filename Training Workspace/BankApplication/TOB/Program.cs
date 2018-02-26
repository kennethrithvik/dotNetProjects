using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOB
{
    class Program
    {
        static void Main(string[] args)
        {
            new AccountPriveledgeManager();
            try
            {

            AccountManager accmgr=new AccountManager();
            IAccount acc1 = accmgr.createAccount("Kenneth", "1234", 700000, AccountType.SAVINGS);
            IAccount acc2 = accmgr.createAccount("AAAAA", "2222", 700000, AccountType.SAVINGS);
            IAccount acc3 = accmgr.createAccount("BBBBBB", "4444", 700000, AccountType.CURRENT);
            IAccount acc4 = accmgr.createAccount("cccccccc", "5555", 747000, AccountType.CORPORATE);

            acc1.open();
            acc2.open();
            acc3.open();
            acc4.open();

            accmgr.deposit(acc1, 10000, TransactionType.DEPOSIT);
            accmgr.Withdraw(acc2, 10000, TransactionType.WITHDRAW,acc2.getPin());
            accmgr.deposit(acc3, 10000, TransactionType.DEPOSIT);

            Console.WriteLine(acc1.ToString()+"\n\n");
            Console.WriteLine(acc2.ToString() + "\n\n");
            Console.WriteLine(acc3.ToString() + "\n\n");
            Console.WriteLine(acc4.ToString() + "\n\n");

            }
            catch (InvalidAccountTypeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This type of account does not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



            Console.ReadLine();

        }
    }
}
