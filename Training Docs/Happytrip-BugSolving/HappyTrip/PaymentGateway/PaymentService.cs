using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PaymentGateway
{
    /// <summary>
    /// Class to implement the payment gateway operations
    /// </summary>
    public class PaymentService : IPaymentService
    {
        #region IPaymentService Members

        private Card theCard;

        /// <summary>
        /// Verifies the card to be used for payment
        /// </summary>
        /// <param name="CardInfo"></param>
        /// <returns>True if card information is valid</returns>
        public bool VerifyCard(Card CardInfo)
        {
            //Logic
            //Store the card info for making payment
            theCard = CardInfo;
            return (IsCardNumberValid(CardInfo.CardNo) 
                && IsCVVNumberProvided(CardInfo.Cvv2No) 
                && IsExpiryDateValid(CardInfo.ExpiryMonth,CardInfo.ExpiryYear));
            
        }

        /// <summary>
        /// Makes the payment for a given transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Returns the payment processed information</returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public PaymentInfo MakePayment(double amount)
        {
            //Logic
            //Use the cardinfo for payment.
            ServiceExceptionInfo info = new ServiceExceptionInfo();
            
                if (amount <= 0)
                {
                    info.ErrorCode = 101;
                    info.Description = "Invalid amount";
                    info.When = DateTime.Now;
                    throw new FaultException<ServiceExceptionInfo>(info, new FaultReason("Error in MakePayment"));
                }
                    return new PaymentInfo() { ReferenceNo = Guid.NewGuid().ToString(), Status = PaymentStatus.Success };
                
            
        }

        #endregion


        #region Validation Helper Methods
        /// <summary>
        /// To check if the card number is valid
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>Returns true if valid</returns>
        private bool IsCardNumberValid(string cardNumber)
        {
            return cardNumber.Length == 16;
        }

        /// <summary>
        /// To verify the cvv2 number of the card
        /// </summary>
        /// <param name="cvv"></param>
        /// <returns>Returns true if valid</returns>
        private bool IsCVVNumberProvided(string cvv)
        {
            return (cvv != null) && (cvv.Length == 3);
        }

        /// <summary>
        /// To verify if the expiry date is valid
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns>Rerurns true if valid</returns>
        private bool IsExpiryDateValid(int month, int year)
        {
            return (year >= DateTime.Now.Year && month <= 12);
        }

        #endregion
    }
}
