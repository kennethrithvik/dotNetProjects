using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent card information to be processed while making a payment
    /// </summary>
    public class Card
    {
        #region Data Members of the class

        public string CardNo;
        public string Name;
        public int ExpiryMonth;
        public int ExpiryYear;
        public string Cvv2No;

        #endregion
    }
}
