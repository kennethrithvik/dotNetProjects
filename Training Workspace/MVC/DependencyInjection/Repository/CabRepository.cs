using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Repository
{
    public class CabRepository:ICabRepository
    {
        static IList<Cab> cablist;
        public CabRepository()
        {
            cablist = new List<Cab>();
            AddCag(new Cab { CabNo = "1", Model = "SUV", Capacity = 7 });
            AddCag(new Cab { CabNo = "2", Model = "MUV", Capacity = 8 });
            AddCag(new Cab { CabNo = "3", Model = "Sedan", Capacity = 5 });
            AddCag(new Cab { CabNo = "4", Model = "Hatchback", Capacity = 5 });
            AddCag(new Cab { CabNo = "5", Model = "SUV", Capacity = 6 });
        }
        public void AddCag(Models.Cab cab)
        {
            cablist.Add(cab);
        }

        public IList<Models.Cab> GetAll()
        {
            return cablist;
        }
    }
}