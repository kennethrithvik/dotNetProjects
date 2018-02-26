using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class Membership
    {
        public string TypeOfMem { get; set; }
        public double Discount { get; set; }
        public double Fees { get; set; }

        public Membership(string typeOfMem, double discount, double fees)
        {
            TypeOfMem = typeOfMem;
            Discount = discount;
            Fees = fees;
        }
    }
}
