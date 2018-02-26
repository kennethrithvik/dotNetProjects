using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Common;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to flights
    /// </summary>
    public class FlightManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private IFlightDAO flightDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FlightManager()
        {
            flightDAO = AirTravelDAOFactory.GetInstance().CreateFlightDAO();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="flightDAO"></param>
        public FlightManager(IFlightDAO flightDAO)
        {
            this.flightDAO = flightDAO;
        }

        #region Method to get all the flights
        /// <summary>
        /// Gets all the flights
        /// </summary>
        /// <exception cref="FlightManagerException">Thorwn when unable to get flights</exception>
        /// <returns>Returns array of flights</returns>
        public Flight[] GetFlights()
        {
			try
			{
                Flights fl = new Flights();
			    Flight[] flightsArr = fl.GetFlightsCollectionForAirline().ToArray();
                SortFlights(flightsArr);
                return flightsArr ;
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to get flights", ex);
			}
        }
        #endregion

		#region Method to sort a list of unsorted flights by name
		/// <summary>
		/// Method to sort a list of unsorted flights by name
		/// </summary>
		/// <param name="flights"></param>
		public void SortFlights(Flight[] flights)
		{
			for (int i = 0; i < flights.Length - 1; ++i)
			{
				for (int j = 0; j < flights.Length-2; ++j)
				{
					if (flights[j].ID>flights[j+1].ID)
					{
						Flight temp = flights[j];
						flights[j] = flights[j+1];
						flights[j+1] = flights[j];
					}
				}
			}
		}
		#endregion

		#region Method to get the flight details for a given flight id
		/// <summary>
		/// Get the flight details for a given flight id
		/// </summary>
		/// <parameter name="flightId"></parameter>
		/// <exception cref="FlightManagerException">Thorwn when unable to get flights</exception>
		/// <returns>Returns a flight object for a given flight id</returns>
		public Flight GetFlight(int flightId)
        {
			try
			{
				return flightDAO.GetFlight(flightId);
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to get flight details", ex);
			}
        }
        #endregion

        #region Method to get the flight details for a given airline id
        /// <summary>
        /// Gets the flight details for a given airline id
        /// </summary>
        /// <parameter name="airlineId"></parameter>
        /// <exception cref="FlightManagerException">Thorwn when unable to get flights for a given airline</exception>
        /// <returns>Returns list of flights for an airline</returns>
        public List<Flight> GetFlightsForAirLine(int airlineId)
        {
			try
			{
				return flightDAO.GetFlights().Where(w => w.AirlineForFlight.Id == airlineId).ToList();
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to get the flight for a given airline", ex);
			}
        }
        #endregion

        #region Method to add the flight with seats for different travelclass
        /// <summary>
        /// Add the flight with seats for different travel class
        /// </summary>
        /// <param name="flight"></param>
        /// <exception cref="FlightManagerException">Thorwn when unable to add a flight</exception>
        /// <returns>Returns the status of adding a flight</returns>
        public bool AddFlight(Flight flight)
        {
			try
			{
                return flightDAO.AddFlight(flight);
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to add flight", ex);
			}
        }
        #endregion

        #region Method to update the existing flight details
        /// <summary>
        /// Update the existing flight details
        /// </summary>
        /// <exception cref="FlightManagerException">Thrown when unable to update a flight</exception>
        /// <param name="flight"></param>
        /// <returns>Retruns the status of the update of a flight</returns>
        public bool UpdateFlight(Flight flight)
        {
			try
			{
                return flightDAO.UpdateFlight(flight);
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to update flight", ex);
			}
        }
        #endregion

        #region Method to update the existing flight details along with seats
        /// <summary>
        /// Update the existing flight details along with seats and class
        /// </summary>
        /// <parameter name="flightClassInfo"></parameter>
        /// <parameter name="flightInfo"></parameter>
        /// <exception cref="FlightManagerException">Thorwn when unable to update flight class</exception>
        /// <returns>Returns the status of the update</returns>
        public int UpdateFlightClass(Flight flightInfo,FlightClass flightClassInfo)
        {
			try
			{
                return flightDAO.UpdateFlightClass(flightInfo, flightClassInfo);
			}
			catch (FlightDAOException ex)
			{
				throw new FlightManagerException("Unable to update flight class", ex);
			}
        }
        #endregion

    }
}

