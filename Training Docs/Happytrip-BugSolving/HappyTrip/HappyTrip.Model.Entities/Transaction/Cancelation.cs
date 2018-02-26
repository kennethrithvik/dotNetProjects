using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    /// <summary>
    /// Class to represent cancelation information for booking
    /// </summary>
    public class Cancelation
    {
        #region Properties of the class

        public DateTime CancelationDate { get; set; }
        public decimal RefundAmount { get; set; }

        #endregion
    }
}
