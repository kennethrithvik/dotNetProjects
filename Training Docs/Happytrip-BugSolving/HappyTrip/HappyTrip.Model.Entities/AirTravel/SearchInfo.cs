using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent the flight search related information
    /// </summary>
    public class SearchInfo
    {
        #region Data Members of the class

        public City FromCity;
        public City ToCity;
        public DateTime OnwardDateOfJourney;
        public DateTime ReturnDateOfJourney;
        public int NoOfSeats;
        public TravelClass Class;
        public TravelDirection Direction;

        #endregion
    }
}
