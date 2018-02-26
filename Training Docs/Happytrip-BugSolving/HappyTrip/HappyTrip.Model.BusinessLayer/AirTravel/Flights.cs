using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.DataAccessLayer.Common;


namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public class Flights
    {
        List<Flight> flights = null;
        private IFlightDAO flightDAO = null;

        public Flights()
        {
            flightDAO = AirTravelDAOFactory.GetInstance().CreateFlightDAO();
        }
        public List<Flight> GetFlightsCollectionForAirline()
        {
            FlightManager fm = new FlightManager();
            flights = new List<Flight>();
            flights = flightDAO.GetFlights().ToList();
            flights.Sort();
            return flights;
        }
    }
}
