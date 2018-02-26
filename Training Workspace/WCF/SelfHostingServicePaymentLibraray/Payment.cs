using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostingServicePaymentLibraray
{
    public class Payment:IPayment
    {
        public bool ValidateCard(CreditCard card)
        {
            bool status = false;
            try
            {
                
                if (card.CCNo.Length > 0 && card.ExpDate != null)
                {
                    if (card.CCNo.Length == 13)
                    {
                        if (DateTime.Now < card.ExpDate)
                            status = true;
                    }
                    else
                        throw new FaultException<CreditCardException>(new CreditCardException() { message = "cc data invalid" }, new FaultReason("cc data not matching"));
                }
            }
            catch (FaultException ex)
            {                
                throw ex;
            }



            return status;
        }
    }
}
