using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MembershipFactory memf = MembershipFactory.GetInstance();
            memf.CreateMembership("gold", 15, 5000);
            RegCustomer regc=new RegCustomer("1","Kenneth","ken@mail.com","01/04/2015",memf.GetMembership("gold"));
        }
    }
}
