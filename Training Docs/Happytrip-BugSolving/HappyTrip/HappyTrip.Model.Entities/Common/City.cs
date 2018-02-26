using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Common
{
    /// <summary>
    /// Class to represent city information
    /// </summary>
    public class City:IComparable
    {
        #region Properties of the class

        public long CityId {get;set;}
        public string Name {get;set; }
        public State StateInfo { get; set; }

        #endregion

        public int CompareTo(object obj)
        {
            City c = (City)obj;
            if (this.Name.CompareTo(c.Name) > 0)
                return 1;
            else if (this.Name.CompareTo(c.Name) == 0)
                return 0;
            else
                return -1;
        }
    }
}
