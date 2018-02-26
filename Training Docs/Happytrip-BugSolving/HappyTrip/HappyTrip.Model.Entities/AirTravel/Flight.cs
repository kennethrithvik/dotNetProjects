﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.AirTravel
{
    /// <summary>
    /// Class to represent flight information for air travel
    /// </summary>
    public class Flight:IComparable
    {
        #region Fields of the class

        /// <summary>
        /// Class of seats for a flight
        /// </summary>
        private List<FlightClass> classes = new List<FlightClass>();

        /// <summary>
        /// Schedules for a flight
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();

        #endregion

        #region Properties of the class

        public long ID { get; set; }
        public string Name { get; set; }
        public Airline AirlineForFlight { get; set; }

        #endregion

        #region Methods of the class

        /// <summary>
        /// Gets all the classes available for a flight
        /// </summary>
        /// <returns></returns>
        public List<FlightClass> GetClasses()
        {
            return classes;
        }

        /// <summary>
        /// Adds a class for a flight
        /// </summary>
        /// <param name="newClass"></param>
        public void AddClass(FlightClass newClass)
        {
            classes.Add(newClass);
        }

        /// <summary>
        /// Gets all the schedules for a flight
        /// </summary>
        /// <returns>Returns the list of schedules</returns>
        public List<Schedule> GetSchedules()
        {
            return schedules;
        }

        /// <summary>
        /// Adds a schedule for a flight
        /// </summary>
        /// <param name="newSchedule"></param>
        public void AddSchedule(Schedule newSchedule)
        {
            schedules.Add(newSchedule);
        }

        #endregion

        public int CompareTo(object obj)
        {
            Flight f = (Flight)obj;
            if (this.Name.CompareTo(f.Name)>0)
                return 1;
            else if (this.Name.CompareTo(f.Name) < 0)
                return -1;
            else
                return 0;
        }
    }
}
