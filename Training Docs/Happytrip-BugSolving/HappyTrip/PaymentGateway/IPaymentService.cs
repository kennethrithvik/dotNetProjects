using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PaymentGateway
{
    /// <summary>
    /// Interface to represent abstractions exposed by the payment gateway
    /// </summary>
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IPaymentService
    {
        /// <summary>
        /// Verifies the card to be used for payment
        /// </summary>
        /// <param name="CardInfo"></param>
        /// <returns>True if card information is valid</returns>
        [OperationContract(IsInitiating=true,IsTerminating=false)]
        bool VerifyCard(Card CardInfo);

        /// <summary>
        /// Makes the payment for a given transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Returns the payment processed information</returns>
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        [FaultContract(typeof(ServiceExceptionInfo))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        PaymentInfo MakePayment(double amount);
    }
}
