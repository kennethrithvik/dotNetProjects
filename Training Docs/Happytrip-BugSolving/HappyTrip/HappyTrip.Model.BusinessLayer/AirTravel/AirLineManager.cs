using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Common;
namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to airlines operation
    /// </summary>
    public class AirLineManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private IAirlineDAO airlineDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AirLineManager()
        {
            airlineDAO = AirTravelDAOFactory.GetInstance().CreateAirlineDAO();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="airlineDAO"></param>
        public AirLineManager(IAirlineDAO airlineDAO)
        {
            this.airlineDAO = airlineDAO;
        }
       

      


        #region Method to get all the airlines
        /// <summary>
        /// Gets all the airlines from the database
        /// </summary>
        /// <exception cref="AirlineManagerException">Throws the exception when airlines is not available</exception>
        /// <returns>Returns the list of airlines</returns>
        public Airline[] GetAirLines()
        {
			//Airline[] airlines = null;
			try
			{
                Airlines airlines = new Airlines();
                airlines.AllAirlines = new List<Airline>();
                airlines.AllAirlines = airlineDAO.GetAirlines().ToList();
                airlines.AllAirlines.Sort();
				return airlines.AllAirlines.ToArray();
			}
			catch (AirlineDAOException ex)
			{
				throw new AirlineManagerException("Unable to get airlines", ex);
			}
        }
        #endregion

		
	}
}