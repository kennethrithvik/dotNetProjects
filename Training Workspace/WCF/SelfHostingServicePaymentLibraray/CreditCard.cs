using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostingServicePaymentLibraray
{
    [DataContract]
    public class CreditCard
    {
        [DataMember]
        public String CCNo { get; set; }


        [DataMember]
        public DateTime ExpDate { get; set; }
    }
}
