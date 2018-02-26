using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
   public class Airlines
    {
       public List<HappyTrip.Model.Entities.AirTravel.Airline> AllAirlines;

       public List<HappyTrip.Model.Entities.AirTravel.Airline> GetAllAirlinesCollecction()
        {
            AirLineManager am = new AirLineManager();
            AllAirlines = new List<Entities.AirTravel.Airline>();
            AllAirlines = am.GetAirLines().ToList();
            AllAirlines.Sort();
           return AllAirlines;
        }


    }
}
