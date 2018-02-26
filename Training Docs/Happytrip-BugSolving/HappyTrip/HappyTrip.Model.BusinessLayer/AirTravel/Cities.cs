using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
   public class Cities
    {

       public  List<HappyTrip.Model.Entities.Common.City> allCities;

       public List<HappyTrip.Model.Entities.Common.City>  GetCities( )
        {

            CityManager cm = new CityManager();
           allCities= new List<Entities.Common.City>();
           allCities = cm.GetCities().ToList();
           allCities.Sort();
           return allCities;
           
        }
    }
}
