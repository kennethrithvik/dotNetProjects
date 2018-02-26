using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Repository
{
    public interface ICabRepository
    {
        void AddCag(Cab cab);
        IList<Cab> GetAll();
    }
}
