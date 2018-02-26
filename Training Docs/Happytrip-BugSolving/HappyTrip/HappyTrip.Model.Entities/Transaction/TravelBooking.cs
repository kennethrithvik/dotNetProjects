using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Transaction
{
    public class TravelBooking
    {
        #region Fields of the class
        private Dictionary<AirTravel.TravelDirection, Booking> Bookings = new Dictionary<AirTravel.TravelDirection, Booking>();
        #endregion

        public bool IsReturnAvailable()
        {
            bool IsAvailable = false;
            try
            {
                if (Bookings[AirTravel.TravelDirection.Return] != null)
                    IsAvailable = true;
            }
            catch (KeyNotFoundException)
            {
                IsAvailable=false;
            }
                            
            
            return IsAvailable;
        }


        public Booking GetBookingForTravel(AirTravel.TravelDirection Direction)
        {
            Booking BookingForTravel = null;
            try
            {
                BookingForTravel = Bookings[Direction];
            }
            catch (KeyNotFoundException)
            {
                                
            }
            

            return BookingForTravel;
        }


        public bool AddBookingForTravel(AirTravel.TravelDirection _direction, Booking _booking)
        {
            if (!Bookings.ContainsKey(_direction))
            {
                Bookings.Add(_direction, _booking);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AirTravel.TravelDirection> GetBookingTravelDirections()
        {
            if (Bookings.Keys.Count == 0)
                throw new BookingTravelDirectionException("Booking Travel Direction Not Available");

            List<AirTravel.TravelDirection> TravelDirections = new List<AirTravel.TravelDirection>();

            foreach (AirTravel.TravelDirection Direction in Bookings.Keys)
            {
                TravelDirections.Add(Direction);
            }

            return TravelDirections;
        }
    }
}
