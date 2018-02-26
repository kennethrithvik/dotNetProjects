using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent payment related information for a transaction
    /// </summary>
    public class Payment
    {
        #region Data Members of the class

        public DateTime PaymentDate;
        public decimal Amount;
        public string ReferenceNo;

        #endregion
    }
}
