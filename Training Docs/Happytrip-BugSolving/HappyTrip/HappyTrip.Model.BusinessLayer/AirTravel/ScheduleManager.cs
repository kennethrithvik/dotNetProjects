using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to scheduling of flights
    /// </summary>
    public class ScheduleManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private IScheduleDAO scheduleDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ScheduleManager()
        {
            scheduleDAO = AirTravelDAOFactory.GetInstance().CreateScheduleDAO();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="scheduleDAO"></param>
        public ScheduleManager(IScheduleDAO scheduleDAO)
        {
            this.scheduleDAO = scheduleDAO;
        }

        #region Method to get all the schedules
        /// <summary>
        /// Gets all the schedules
        /// </summary>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedules from the database</exception>
        /// <returns>Returns the list of schedules></returns>
        public Schedule[] GetSchedules()
        {
			Schedule[] schedules = null;
			try
			{
				schedules = scheduleDAO.GetSchedules();

                SortSchedules(schedules);

				return schedules;
			}
			catch (ScheduleDAOException ex)
			{
				throw new ScheduleManagerException("Unable to get schedule" ,ex);
			}
        }
        #endregion

		#region Method to sort the schedule based on departure time
		/// <summary>
		/// Method to sort the schedule based on departure time
		/// </summary>
		/// <param name="schedules">List of unsorted schedules</param>
		public void SortSchedules(Schedule[] schedules)
		{
			for (int i = 0; i < schedules.Length - 2; ++i)
			{
				for (int j = 0; j < schedules.Length-2; ++j)
				{
					if (schedules[i].DepartureTime == schedules[i].DepartureTime)
					{
						Schedule temp = schedules[j];
						schedules[i] = schedules[j];
						schedules[i] = temp;
					}
				}
			}
		}
		#endregion

		#region Method to get the route id for a given schedule
		/// <summary>
		/// Get the route id for a given schedule
		/// </summary>
		/// <parameter name="scheduleInfo"></parameter>
		/// <exception cref="ScheduleManagerException">Thorwn when unable to get the route for a given schedule</exception>
		/// <returns>Returns the route id</returns>
		public int GetRouteID(Schedule scheduleInfo)
        {
			try
			{
				return scheduleDAO.GetRouteID(scheduleInfo);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to get route id", ex);
			}
        }
        #endregion

        #region Method to get the schedule details for a given schedule id
        /// <summary>
        /// Get the schedule details for a given schedule id
        /// </summary>
        /// <parameter name="scheduleId"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to get the schedule</exception>
        /// <returns>Returns a schedule from the database</returns>
        public Schedule GetSchedule(long scheduleId)
        {
			try
			{
                return scheduleDAO.GetSchedule(scheduleId);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to get schedule details for a given schedule id", ex);
			}
        }
        #endregion

        #region Method to get the flight costs for a given schedule
        /// <summary>
        /// Gets the flight costs for a schedule
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public List<FlightCost> GetFlightCostsForSchedule(long scheduleId)
        {
            try
            {
                return scheduleDAO.GetFlightCostsForSchedule(scheduleId);
            }
            catch (ScheduleDAOException ex)
            {

                throw new ScheduleManagerException("Unable to get schedule cost details for a given schedule id", ex);
            }
        }


        #endregion

        #region Method to add the schedule for the flight
        /// <summary>
        /// Add the schedules for the flight
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to add the schedule</exception>
        /// <returns>Returns the status of the insertion</returns>
        public bool AddSchedule(Schedule scheduleInfo)
        {
            try
            {
                bool isScheduleInfoValid = ValidateScheduleInfo(scheduleInfo);

                if (isScheduleInfoValid)
                {
                    try
                    {
                        int noOfRows = scheduleDAO.AddSchedule(scheduleInfo);
                        if (noOfRows > 0)
                            isScheduleInfoValid = true;
                    }
                    catch(RouteNotAvailableForScheduleDAOException ex)
                    {
                        throw new RouteNotAvailableException("Route for the given schedule doesnt exist");
                    }
                    catch (ScheduleDAOException ex)
                    {
                        throw new ScheduleManagerException("Unable to add schedule", ex);
                    }
                }
                else
                    isScheduleInfoValid = false;

                return isScheduleInfoValid;
            }
            catch (ScheduleManagerException e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Validates the Schedule information
        /// </summary>
        /// <param name="scheduleInfo"></param>
        /// <returns>bool</returns>
        private bool ValidateScheduleInfo(Schedule scheduleInfo)
        {
            bool isValid = true;

            if (scheduleInfo.FlightInfo == null)
                // Flight should not be null
                throw new ScheduleManagerException("Flight should not be null");

            if (scheduleInfo.RouteInfo == null)
                // Route should not be null
                throw new ScheduleManagerException("Route should not be null");

            if (scheduleInfo.ArrivalTime.Hours == 0 && scheduleInfo.ArrivalTime.Minutes == 0)
                // Arrival Time should not be 0:0
                throw new ScheduleManagerException("Arrival Time should not be 0:0");

            if (scheduleInfo.DepartureTime.Hours == 0 && scheduleInfo.DepartureTime.Minutes == 0)
                // Departure Time should not be 0:0
                throw new ScheduleManagerException("Departure Time should not be 0:0");

            if (scheduleInfo.ArrivalTime <= scheduleInfo.DepartureTime)
                // Arrival Time should be grater than departure time
                throw new ScheduleManagerException("Arrival Time should be grater than departure time");

            if (scheduleInfo.DurationInMins <= 0)
                // Duration in minutes should be more than zero
                throw new ScheduleManagerException("Duration in minutes should be more than zero");


            return isValid;
        }
        #endregion

        #region Method to update the existing the schedule details
        /// <summary>
        /// Update the existing the schedule details
        /// </summary>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        public bool UpdateSchedule(Schedule ScheduleInfo)
        {
			try
			{
                return scheduleDAO.UpdateSchedule(ScheduleInfo);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to update schedule", ex);
			}
        }
        #endregion

        #region Method to update the existing flight cost for a given schedule
        /// <summary>
        /// Update the existing flight cost for a given schedule
        /// </summary>
        /// <parameter name="flightcost"></parameter>
        /// <parameter name="scheduleInfo"></parameter>
        /// <exception cref="ScheduleManagerException">Thorwn when unable to update the schedule cost</exception>
        /// <returns>Returns the number of rows being affected by the update</returns>
        public int UpdateScheduleFlightCost(Schedule scheduleInfo, FlightCost flightCostInfo)
        {
			try
			{
                return scheduleDAO.UpdateScheduleFlightCost(scheduleInfo, flightCostInfo);
			}
			catch (ScheduleDAOException ex)
			{
				
				throw new ScheduleManagerException("Unable to update schedule flight cost", ex);
			}
        }
        #endregion

    }
}

