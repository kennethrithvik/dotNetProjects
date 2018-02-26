using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class RegCustomer:Customer
    {
        public string DtReg { get; set; }
        public Membership Mem { get; set; }


        public RegCustomer(string custId, string name, string email, string dtReg, Membership mem) : base(custId, name, email)
        {
            DtReg = dtReg;
            Mem = mem;
        }
    }
}
