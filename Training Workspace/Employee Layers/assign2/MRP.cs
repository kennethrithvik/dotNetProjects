using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2
{
    struct MRP
    {
        public double Bprice;
        public double VAT,Dis;

        public MRP(double bp,double vat,double dis)
        {
            Bprice = bp;
            VAT = vat;
            Dis = dis;


        }
        public double GetGross()
        {
            Bprice =Bprice-(Bprice*(Dis/100));
            Bprice=Bprice + (Bprice * (VAT / 100));
            return Bprice;
        }
    }
}
