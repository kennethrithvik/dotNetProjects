using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLLayerCreditCard.CardRepository
{
    public class CardRepo:ICardRepo
    {
        public CardRepo()
        {

        }
        public bool ValidateCard(string CCN, DateTime ExpDate)
        {
            CreditCardServiceReference.CreditCardServiceClient cc = new CreditCardServiceReference.CreditCardServiceClient();
            bool result = cc.ValidateCard(CCN, ExpDate);
            return result;
        }
    }
}