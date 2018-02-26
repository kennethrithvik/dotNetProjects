using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSDAL
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        List<T> GetByName(string nam);
        void Add(T emp);
        void Update(T emp);
        void Delete(int id);
    }

}
