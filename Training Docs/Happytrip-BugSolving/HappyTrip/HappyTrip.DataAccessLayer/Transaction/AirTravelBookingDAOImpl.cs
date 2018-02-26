using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Transaction;
using System.Data;
using System.Data.Common;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.Transaction
{
    /// <summary>
    /// Class to represent the database activities related to AirTravel Booking
    /// </summary>
    class AirTravelBookingDAOImpl : IBookingDAOImpl
    {
        #region Old- Commented Code Method to store booking details for an air travel

        ///// <summary>
        ///// Inserts into database the booking for air travel
        ///// </summary>
        ///// <param name="newBooking"></param>
        ///// <param name="dbConnection"></param>
        ///// <exception cref="AirTravelBookingException">Throws the AirTravelBookingException, if unable to store a booking</exception>
        ///// <returns>Returns the booking reference number</returns>
        //public string MakeBooking(Booking newBooking, Database dbConnection)
        //{
        //    string bookingReferenceNo = string.Empty;

        //    //Downcast to flight booking
        //    FlightBooking airBooking = (FlightBooking)newBooking;

        //    try
        //    {
        //        //Write code to store data into database
        //        DbCommand command = dbConnection.GetStoredProcCommand("BookFlightTicket");
        //        dbConnection.AddInParameter(command, "@TypeID", DbType.Int32, (int)airBooking.BookingType);
        //        dbConnection.AddInParameter(command, "@DateOfJourney", DbType.DateTime, airBooking.DateOfJourney);
        //        dbConnection.AddInParameter(command, "@NoOfSeats", DbType.Int32, airBooking.NoOfSeats);
        //        dbConnection.AddInParameter(command, "@ClassID", DbType.Int32, (int)airBooking.Class.ClassInfo);
        //        dbConnection.AddInParameter(command, "@ContactName", DbType.String, airBooking.Contact.ContactName);
        //        dbConnection.AddInParameter(command, "@Address", DbType.String, airBooking.Contact.Address);
        //        dbConnection.AddInParameter(command, "@City", DbType.String, airBooking.Contact.City);
        //        dbConnection.AddInParameter(command, "@State", DbType.String, airBooking.Contact.State);
        //        dbConnection.AddInParameter(command, "@PinCode", DbType.String, airBooking.Contact.PinCode);
        //        dbConnection.AddInParameter(command, "@Email", DbType.String, airBooking.Contact.Email);
        //        dbConnection.AddInParameter(command, "@PhoneNo", DbType.String, airBooking.Contact.PhoneNo);
        //        dbConnection.AddInParameter(command, "@MobileNo", DbType.String, airBooking.Contact.MobileNo);
        //        dbConnection.AddInParameter(command, "@PaymentRefernceNo", DbType.String, airBooking.PaymentInfo.ReferenceNo);
        //        dbConnection.AddInParameter(command, "@TotalCost", DbType.Decimal, airBooking.TotalCost);

        //        //Concatenate to send to database as a single string
        //        string passengerDetails = String.Empty;
        //        string name = String.Empty;
        //        string gender = String.Empty;
        //        string dob = String.Empty;

        //        foreach (Passenger p in airBooking.GetPassengers())
        //        {
        //            name = p.Name;
        //            gender = p.Gender.ToString();
        //            dob = p.DateOfBirth.ToShortDateString();

        //            passengerDetails = name + "|" + gender + "|" + dob + ";";
        //        }

        //        dbConnection.AddInParameter(command, "@PassengerDetails", DbType.String, passengerDetails);
        //        dbConnection.AddOutParameter(command, "@BookingReferenceNumber", DbType.String, 100);
        //        dbConnection.AddOutParameter(command, "@LastBookingID", DbType.Int64, 0);

        //        //Execute the command
        //        dbConnection.ExecuteNonQuery(command);

        //        //Get the values from the database
        //        bookingReferenceNo = dbConnection.GetParameterValue(command, "@BookingReferenceNumber").ToString();
        //        long bookingId = Convert.ToInt64(dbConnection.GetParameterValue(command, "@LastBookingID"));

        //        //Insert the schedules for a booking
        //        foreach (Schedule s in airBooking.TravelScheduleInfo.GetSchedules())
        //        {
        //            try
        //            {
        //                InsertBookingSchedule(bookingId, s.ID, s.GetFlightCosts().FirstOrDefault().CostPerTicket, dbConnection);
        //            }
        //            catch (AirTravelBookingException)
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //    catch(AirTravelBookingException)
        //    {
        //        throw;
        //    }
        //    catch (DbException ex)
        //    {
        //        throw new AirTravelBookingException("Unable to insert air travel booking", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new AirTravelBookingException("Unable to insert air travel booking", ex);
        //    }

        //    return bookingReferenceNo;
        //}

        ///// <summary>
        ///// Inserts the schedule for a booking
        ///// </summary>
        ///// <param name="bookingId"></param>
        ///// <param name="scheduleId"></param>
        ///// <param name="costPerTicket"></param>
        ///// <param name="dbConnection"></param>
        ///// <returns></returns>
        //private bool InsertBookingSchedule(long bookingId, long scheduleId, decimal costPerTicket, Database dbConnection)
        //{
        //    bool isStored = false;

        //    try
        //    {
        //        //Write code to store data into database
        //        DbCommand command = dbConnection.GetStoredProcCommand("InsertFlightTicketSchedule");
        //        dbConnection.AddInParameter(command, "@BookingId", DbType.Int64, bookingId);
        //        dbConnection.AddInParameter(command, "@ScheduleId", DbType.Int64, scheduleId);
        //        dbConnection.AddInParameter(command, "@CostPerTicket", DbType.Decimal, costPerTicket);

        //        //Execute the command
        //        dbConnection.ExecuteNonQuery(command);

        //        isStored = true;
        //    }
        //    catch (DbException ex)
        //    {
        //        throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
        //    }

        //    return isStored;
        //}
        #endregion

        #region Method to store booking details for an air travel

        /// <summary>
        /// Inserts into database the booking for air travel
        /// </summary>
        /// <param name="newBooking"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="AirTravelBookingException">Throws the AirTravelBookingException, if unable to store a booking</exception>
        /// <returns>Returns the booking reference number</returns>
        public string MakeBooking(Booking newBooking, IDbConnection dbConnection)
        {
            string bookingReferenceNo = string.Empty;

            //Downcast to flight booking
            FlightBooking airBooking = (FlightBooking)newBooking;

            try
            {
                dbConnection.Open();

                IDbCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "BookFlightTicket";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@TypeID";
                p1.Value = (int)airBooking.BookingType;
                cmd.Parameters.Add(p1);

                IDbDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@DateOfJourney";
                p2.Value = airBooking.DateOfJourney;
                cmd.Parameters.Add(p2);

                IDbDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@NoOfSeats";
                p3.Value = airBooking.NoOfSeats;
                cmd.Parameters.Add(p3);

                IDbDataParameter p4 = cmd.CreateParameter();
                p4.ParameterName = "@ClassID";
                p4.Value = (int)airBooking.Class.ClassInfo;
                cmd.Parameters.Add(p4);


                IDbDataParameter p5 = cmd.CreateParameter();
                p5.ParameterName = "@ContactName";
                p5.Value = airBooking.Contact.ContactName;
                cmd.Parameters.Add(p5);

                IDbDataParameter p6 = cmd.CreateParameter();
                p6.ParameterName = "@Address";
                p6.Value = airBooking.Contact.Address;
                cmd.Parameters.Add(p6);

                IDbDataParameter p7 = cmd.CreateParameter();
                p7.ParameterName = "@City";
                p7.Value = airBooking.Contact.City;
                cmd.Parameters.Add(p7);

                IDbDataParameter p8 = cmd.CreateParameter();
                p8.ParameterName = "@State";
                p8.Value = airBooking.Contact.State;
                cmd.Parameters.Add(p8);


                IDbDataParameter p9 = cmd.CreateParameter();
                p9.ParameterName = "@PinCode";
                p9.Value = "000000";
                cmd.Parameters.Add(p9);


                IDbDataParameter p10 = cmd.CreateParameter();
                p10.ParameterName = "@Email";
                p10.Value = airBooking.Contact.Email;
                cmd.Parameters.Add(p10);


                IDbDataParameter p11 = cmd.CreateParameter();
                p11.ParameterName = "@PhoneNo";
                p11.Value = airBooking.Contact.PhoneNo;
                cmd.Parameters.Add(p11);

                IDbDataParameter p12 = cmd.CreateParameter();
                p12.ParameterName = "@MobileNo";
                p12.Value = airBooking.Contact.MobileNo;
                cmd.Parameters.Add(p12);


                IDbDataParameter p13 = cmd.CreateParameter();
                p13.ParameterName = "@PaymentRefernceNo";
                p13.Value = airBooking.PaymentInfo.ReferenceNo;
                cmd.Parameters.Add(p13);

                IDbDataParameter p14 = cmd.CreateParameter();
                p14.ParameterName = "@TotalCost";
                p14.Value = airBooking.TotalCost;
                cmd.Parameters.Add(p14);

                //Concatenate to send to database as a single string
                string passengerDetails = String.Empty;
                string name = String.Empty;
                string gender = String.Empty;
                string dob = String.Empty;

                foreach (Passenger p in airBooking.GetPassengers())
                {
                    name = p.Name;
                    gender = p.Gender.ToString();
                    dob = p.DateOfBirth.ToShortDateString();

                    passengerDetails += name + "|" + gender + "|" + dob + ";";
                }

                IDbDataParameter p15 = cmd.CreateParameter();
                p15.ParameterName = "@PassengerDetails";
                p15.Value = passengerDetails;
                cmd.Parameters.Add(p15);

                IDbDataParameter bookingRefNo = cmd.CreateParameter();
                bookingRefNo.Size = -1;
                bookingRefNo.ParameterName = "@BookingReferenceNumber";
                bookingRefNo.Direction = ParameterDirection.Output;
                bookingRefNo.Value = "";
                cmd.Parameters.Add(bookingRefNo);

                IDbDataParameter lastBookingId = cmd.CreateParameter();
                lastBookingId.ParameterName = "@LastBookingID";
                lastBookingId.Direction = ParameterDirection.Output;
                lastBookingId.Value = 0;
                cmd.Parameters.Add(lastBookingId);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the values from the database
                bookingReferenceNo = bookingRefNo.Value.ToString();
                long bookingId = Convert.ToInt64(lastBookingId.Value);

                //Insert the schedules for a booking
                foreach (Schedule s in airBooking.TravelScheduleInfo.GetSchedules())
                {
                    try
                    {
                        InsertBookingSchedule(bookingId, s.ID, s.GetFlightCosts().FirstOrDefault().CostPerTicket, dbConnection);
                    }
                    catch (AirTravelBookingException)
                    {
                        throw;
                    }
                }
            }
            catch (AirTravelBookingException)
            {
                throw;
            }
            catch (DbException ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel booking", ex);
            }
            catch (Exception ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel booking", ex);
            }
            finally
            {
                if (dbConnection != null && dbConnection.State == ConnectionState.Open)
                    dbConnection.Close();
            }

            return bookingReferenceNo;
        }

        /// <summary>
        /// Inserts the schedule for a booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="costPerTicket"></param>
        /// <param name="dbConnection"></param>
        /// <returns></returns>
        private bool InsertBookingSchedule(long bookingId, long scheduleId, decimal costPerTicket, IDbConnection dbConnection)
        {
            bool isStored = false;
            try
            {
                //Write code to store data into database
                IDbCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = "InsertFlightTicketSchedule";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@BookingId";
                p1.Value = bookingId;
                cmd.Parameters.Add(p1);

                IDbDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@ScheduleId";
                p2.Value = scheduleId;
                cmd.Parameters.Add(p2);

                IDbDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@CostPerTicket";
                p3.Value = costPerTicket;
                cmd.Parameters.Add(p3);

                //Execute the command
                cmd.ExecuteNonQuery();
                isStored = true;
            }
            catch (DbException ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
            }
            catch (Exception ex)
            {
                throw new AirTravelBookingException("Unable to insert air travel schedule", ex);
            }

            return isStored;
        }
        #endregion
    }
}
