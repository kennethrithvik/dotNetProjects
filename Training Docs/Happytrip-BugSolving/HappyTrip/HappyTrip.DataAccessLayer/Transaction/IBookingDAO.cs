using System;
using HappyTrip.Model.Entities.Transaction;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Interface to represent booking related database activities
    /// </summary>
    public interface IBookingDAO
    {
        /// <summary>
        /// Inserts into database the booking information for different types
        /// </summary>
        /// <param name="newBooking"></param>
        /// <exception cref="BookingDAOException">Throws the BookingDAOException, if unable to store a booking</exception>
        /// <returns>Returns the booking reference number</returns>
        string MakeBooking(Booking newBooking);
    }
}
