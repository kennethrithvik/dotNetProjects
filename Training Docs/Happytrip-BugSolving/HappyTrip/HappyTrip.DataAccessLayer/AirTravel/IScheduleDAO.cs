using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the schedule operations to be performed on the database
    /// </summary>
    public interface IScheduleDAO
    {
        int GetRouteID(Model.Entities.AirTravel.Schedule ScheduleInfo);
        Schedule[] GetSchedules();
        int AddSchedule(Schedule scheduleInfo);
        bool UpdateSchedule(Schedule scheduleInfo);
        int UpdateScheduleFlightCost(Schedule scheduleInfo, FlightCost flightCostInfo);
        Schedule GetSchedule(long scheduleId);
        List<FlightCost> GetFlightCostsForSchedule(long scheduleId);
    }
}
