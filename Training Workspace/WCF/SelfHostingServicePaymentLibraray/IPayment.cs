using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostingServicePaymentLibraray
{
    [ServiceContract]
    public interface IPayment
    {
        [OperationContract]
        [FaultContract(typeof(CreditCardException))]
        bool ValidateCard(CreditCard cc);
    }
}
