using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class MembershipFactory
    {
        private Dictionary<string,Membership> mems=new Dictionary<string, Membership>();
        private MembershipFactory()
        {
        }

        public static MembershipFactory mf;

        public static MembershipFactory GetInstance()
        {
            return mf;
        }

        public Membership CreateMembership(string typeOfMem, double discount, double fees)
        {
            Membership mem = new Membership(typeOfMem, discount, fees);
            mems.Add(mem.TypeOfMem,mem);
            return mem;
        }

        public Membership GetMembership(string type)
        {
            return mems[type];
        }
    }
}
