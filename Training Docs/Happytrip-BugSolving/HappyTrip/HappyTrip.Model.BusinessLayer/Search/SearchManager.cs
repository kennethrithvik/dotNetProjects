using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Search;

namespace HappyTrip.Model.BusinessLayer.Search
{
    /// <summary>
    /// Class to manage the activities related to search of flights on the portal
    /// </summary>
    class SearchManager : HappyTrip.Model.BusinessLayer.Search.ISearchManager
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private ISearchDAO searchDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchManager()
        {
            searchDAO = SearchDAOFactory.GetInstance().Create();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="searchDAO"></param>
        public SearchManager(ISearchDAO searchDAO)
        {
            this.searchDAO = searchDAO;
        }

        #region Methods to search for flights and return the search results based on the search criteria
        /// <summary>
        /// Gets the flight schedules based on the search criteria. 
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <exception cref="FlightsNotAvailableException">Thorws an exception when unable to retrieve flights</exception>
        /// <returns>Returns a search log to the caller</returns>
        public SearchLog SearchForFlights(SearchInfo searchInformation)
        {
            //Declaration
            SearchResult result = new SearchResult();
            SearchLog log = new SearchLog();
            try
            {
                bool isValid = ValidateSearchInformation(searchInformation);

                if (isValid)
                {
                    result = GetSearchResult(searchInformation, result);

                    //Add the result to searchlog based on it being Onward or Return
                    AddSearchResultToLog(TravelDirection.OneWay, result, log);

                    if (searchInformation.Direction == TravelDirection.Return)
                    {
                        SearchInfo info = new SearchInfo();
                        info.Class = searchInformation.Class;
                        info.FromCity = searchInformation.ToCity;
                        info.ToCity = searchInformation.FromCity;

                        SearchResult resultReturn = new SearchResult();
                        resultReturn = GetSearchResult(info, resultReturn);
                        AddSearchResultToLog(TravelDirection.Return, resultReturn, log);
                    }
                }
                else
                {
                    throw new FlightsNotAvailableException("Search Information Invalid");
                }
            }
            catch (FlightsNotAvailableException ex)
            {
                throw ex;    //new FlightsNotAvailableException("Search Information Invalid");
            }
            catch (Exception ex)
            {
                throw;
            }

            //5. Return Log
            return log;
        }

        #region Validate the search information provided
        /// <summary>
        /// Validates the search information provided for searching flights
        /// </summary>
        /// <param name="searchInformation"></param>
        private bool ValidateSearchInformation(SearchInfo searchInformation)
        {
            bool isValid = true;
            DateTime dt = new DateTime(1900, 1, 1);

            if (searchInformation.Direction == TravelDirection.OneWay)
            {
                if (searchInformation.OnwardDateOfJourney.Date >= DateTime.Now.Date)
                    isValid = true;

                else if (searchInformation.OnwardDateOfJourney == dt)
                    //isValid = false;
                    throw new FlightsNotAvailableException("Onward Date Of Journey cannot be null");

                else if (searchInformation.OnwardDateOfJourney < DateTime.Now.Date)
                    //isValid = false;
                    throw new FlightsNotAvailableException("Onward Date Of Journey is less than today's date");

                else
                {
                    isValid = false;
                }
                

                
            }
            else if (searchInformation.Direction == TravelDirection.Return)
            {
                if (searchInformation.OnwardDateOfJourney == dt )
                    // Onward Date Of Journey and Retrun Date Of Journey cannot be null
                    //isValid = false;
                    throw new FlightsNotAvailableException("Onward Date Of Journey cannot be null");

                else if (searchInformation.ReturnDateOfJourney == dt)
                    //isValid = false;
                    throw new FlightsNotAvailableException("Return Date Of Journey cannot be null");

                else if (searchInformation.OnwardDateOfJourney < DateTime.Now.Date)
                    //isValid = false;
                    throw new FlightsNotAvailableException("Onward Date Of Journey is less than today's date");

                else if (searchInformation.ReturnDateOfJourney.Date < DateTime.Now.Date)
                    // Onward Date is less than the Current Date
                    //isValid = false;
                    throw new FlightsNotAvailableException("Return Date Of Journey is less than today's date");

                else if (searchInformation.OnwardDateOfJourney > searchInformation.ReturnDateOfJourney)
                    //Onward Date is greater than Return Date
                    //isValid = false;
                    throw new FlightsNotAvailableException("Onward date of journey is greater than Return Date Of Journey");
            }

            return isValid;
        }
        #endregion

        /// <summary>
        /// Gets the search result for the search criteria
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <param name="searchInformation"></param>
        /// <exception cref="FlightsNotAvailableException">Thorws the exception when flights are not available for the given search information</exception>
        /// <returns>Returns the search result for the given search information</returns>
        private SearchResult GetSearchResult(SearchInfo searchInformation, SearchResult result)
        {
            try
            {
                //Get the Schedules from the database based on the search information
                Schedules scheduleCollection = searchDAO.SearchForFlight(searchInformation);
                if (scheduleCollection == null)
                    throw new FlightsNotAvailableException("Flights not available");

                //Add search result for direct flights from the schedules obtained from database
                //based on the search criteria
                try
                {
                    AddSearchResultForDirectFlights(searchInformation, scheduleCollection, result);
                }
                catch (DirectFlightsNotAvailableException)
                {

                }

                //Add search result for connecting flights from the schedules obtained from database
                //based on the search criteria
                try
                {
                    AddSearchResultForConnectingFlights(searchInformation, scheduleCollection, result);
                }
                catch (ConnectingFlightsNotAvailableException)
                {

                }
                
            }
            catch (SearchFlightDAOException ex)
            {
                throw new FlightsNotAvailableException("Unable to Retrieve Flights", ex);
            }
            catch (Exception ex)
            {
                throw new FlightsNotAvailableException("Unable to Retrieve Flights", ex);
            }
            

            return result;
        }

        /// <summary>
        /// Adds the search result for direct flights into the schedule for travel
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <param name="scheduleCollection"></param>
        /// <param name="result"></param>
        /// <exception cref="DirectFlightsNotAvailableException">Throws the exception when direct flights are not available for given search information</exception>
        private void AddSearchResultForDirectFlights(SearchInfo searchInformation, Schedules scheduleCollection, SearchResult result)
        {
            TravelSchedule scheduleForTravel = null;

            foreach (Schedule s in scheduleCollection)
            {
                if (s.RouteInfo.FromCity.CityId == searchInformation.FromCity.CityId && s.RouteInfo.ToCity.CityId == searchInformation.ToCity.CityId)
                {
                    //Create a new TravelSchedule
                    scheduleForTravel = CreateTravelSchedule(ScheduleType.Direct);

                    //Add schedules to Travel Schedule
                    AddScheduleForTravel(scheduleForTravel, s);

                    //Compute total cost for the Travel Schedule
                    CalculateTotalCostForTravel(scheduleForTravel);

                    //Add the travel schedule defined to the search result
                    AddTravelScheduleToResult(scheduleForTravel, result);
                }
            }

            if (scheduleForTravel == null)
                throw new DirectFlightsNotAvailableException("Direct Flights Not Available");
        }

        /// <summary>
        /// Adds the search result for connecting flights in the schedule
        /// </summary>
        /// <param name="searchInformation"></param>
        /// <param name="scheduleCollection"></param>
        /// <param name="result"></param>
        /// <exception cref="ConnectingFlightsNotAvailableException">Throws the exception when connecting flights are not available for given search information</exception>
        private void AddSearchResultForConnectingFlights(SearchInfo searchInformation, Schedules scheduleCollection, SearchResult result)
        {
            Schedules connectingSchedules = null;
            bool isConnecting = false;
            TravelSchedule scheduleForTravel = null;

            foreach (Schedule s in scheduleCollection)
            {
                connectingSchedules = null;
                isConnecting = false;

                if (s.RouteInfo.FromCity.CityId == searchInformation.FromCity.CityId && s.RouteInfo.ToCity.CityId != searchInformation.ToCity.CityId)
                {
                    //Create connecting schedules collection and add the current schedule
                    connectingSchedules = new Schedules();
                    connectingSchedules.AddSchedule(s);

                    isConnecting = FindFlightSchedule(searchInformation.ToCity, scheduleCollection, s, connectingSchedules);
                    if (isConnecting)
                    {
                        //Create a new TravelSchedule
                        scheduleForTravel = CreateTravelSchedule(ScheduleType.Connecting);

                        //Add schedules to Travel Schedule
                        AddScheduleForTravel(scheduleForTravel, connectingSchedules);

                        //Compute total cost for the Travel Schedule
                        CalculateTotalCostForTravel(scheduleForTravel);

                        //Add the travel schedule defined to the search result
                        AddTravelScheduleToResult(scheduleForTravel, result);
                    }
                }
            }

            if (scheduleForTravel == null)
                throw new ConnectingFlightsNotAvailableException("Connecting Flights Not Available");
        }

        /// <summary>
        /// Adds the search result to log
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="result"></param>
        /// <param name="log"></param>
        private void AddSearchResultToLog(TravelDirection direction, SearchResult result, SearchLog log)
        {
            log.AddSearchResultToLog(direction, result);
        }

        /// <summary>
        /// Gets the connecting flight schedules for a given schedule
        /// </summary>
        /// <param name="toCity"></param>
        /// <param name="schCollection"></param>
        /// <param name="s"></param>
        /// <param name="connectingSchedules"></param>
        /// <returns>Returns the status of whether the connecting schedules were found or not</returns>
        private bool FindFlightSchedule(City toCity, Schedules schCollection, Schedule s, Schedules connectingSchedules)
        {
            bool isConnecting = false;

            foreach (Schedule cs in schCollection)
            {
                if (cs.RouteInfo.FromCity.CityId == s.RouteInfo.ToCity.CityId)
                {
                    connectingSchedules.AddSchedule(cs);

                    if (cs.RouteInfo.ToCity.CityId == toCity.CityId)
                    {
                        isConnecting = true;
                        break;
                    }
                    else
                        isConnecting = FindFlightSchedule(toCity, schCollection, cs, connectingSchedules);
                }
            }

            return isConnecting;
        }

        /// <summary>
        /// Creates a travel schedule based on the type of schedule
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Returns a TravelSchedule object for a given type</returns>
        private TravelSchedule CreateTravelSchedule(ScheduleType type)
        {
            TravelSchedule scheduleForTravel = new TravelSchedule();
            scheduleForTravel.Type = type;

            return scheduleForTravel;

        }

        /// <summary>
        /// Adds the schedule to the travel schedule for direct flight
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="schedule"></param>
        private void AddScheduleForTravel(TravelSchedule scheduleForTravel, Schedule schedule)
        {
            scheduleForTravel.AddSchedule(schedule);
        }

        /// <summary>
        /// Adds the schedule to the travel schedule for connecting flights
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="schedules"></param>
        private void AddScheduleForTravel(TravelSchedule scheduleForTravel, Schedules schedules)
        {
            foreach(Schedule s in schedules)
                scheduleForTravel.AddSchedule(s);
        }

        /// <summary>
        /// Calculates the total cost for each travel schedule
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        private void CalculateTotalCostForTravel(TravelSchedule scheduleForTravel)
        {
            foreach (Schedule s in scheduleForTravel.GetSchedules())
            {
                scheduleForTravel.TotalCostPerTicket = s.GetFlightCosts().FirstOrDefault().CostPerTicket;
            }
        }

        /// <summary>
        /// Adds the travel schedule to search result
        /// </summary>
        /// <param name="scheduleForTravel"></param>
        /// <param name="result"></param>
        private void AddTravelScheduleToResult(TravelSchedule scheduleForTravel, SearchResult result)
        {
            result.AddTravelSchedule(scheduleForTravel);
        }
        #endregion

        #region Method to get all the cities with state information
        /// <summary>
        /// Gets the cities in the database
        /// </summary>
        /// <exception cref="CitiesNotAvailableException">Thorws exception when cities are not available to be returned</exception>
        /// <returns>List of cities</returns>
        public List<City> GetCities()
        {
			//first comment
			List<City> cities;

            try
            {
                cities = searchDAO.GetCities();
            }
            catch (DataAccessLayer.Common.CityDAOException ex)
            {
                throw new CitiesNotAvailableException("Unable to get cities", ex);
            }

            return cities;
        }
        #endregion

        #region Method to get the availability for a travel schedule
        /// <summary>
        /// Gets the availability of seats for a given travel schedule
        /// </summary>
        /// <param name="scheduleForAvailability"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="tClass"></param>
        /// <returns>Returns true if seats are available, else false</returns>
        public bool GetAvailabilityForSchedule(Schedule scheduleForAvailability, int numberOfSeats, DateTime dateOfJourney, TravelClass tClass)
        {
            bool isAvailable = false;

            try
            {
                isAvailable = searchDAO.GetAvailabilityForSchedule(scheduleForAvailability, numberOfSeats, dateOfJourney, tClass);
            }
            catch (FlightAvailabilityDAOException ex)
            {
                throw new FlightSeatsAvailabilityException("Seats Not Available", ex);
            }
            catch (Exception ex)
            {
                throw new FlightSeatsAvailabilityException("Seats Not Available", ex);
            }
            

            return isAvailable;
        }

        #endregion
    }
}
