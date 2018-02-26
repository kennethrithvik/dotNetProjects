using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerDemo.Models
{
    public class CityData
    {
        private IList<City> citylist;
        public CityData()
        {
            citylist = new List<City>();
        }
        public void AddCity(City ct)
        {
            citylist.Add(ct);
        }
        public IList<City> GetList()
        {
            return citylist;
        }
    }
}