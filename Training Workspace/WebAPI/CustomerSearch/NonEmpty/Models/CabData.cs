using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NonEmpty.Models
{
    public class CabData
    {
        public IList<Cab> GetAll()
        {
            IList<Cab> clist = new List<Cab>();
            clist.Add(new Cab { CabId = 1, Capacity = 4, Model = "Hatchback" });
            clist.Add(new Cab { CabId = 2, Capacity = 6, Model = "SUV" });
            clist.Add(new Cab { CabId = 3, Capacity = 5, Model = "Sedan" });
            clist.Add(new Cab { CabId = 4, Capacity = 7, Model = "MUV" });
            return clist;
        }
    }
}