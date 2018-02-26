using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    public interface IInterface
    {
        int ID { get; set; }
    }
    public class MyGenericClass<T> where T: class ,IInterface
    {
        private List<T> listEmps;

        public MyGenericClass()
        {
                listEmps=new List<T>();
        }

        public void Add(T emp)
        {
            listEmps.Add(emp);
        }

        public T GetByID(int id)
        {
            T temp=default(T);
            foreach (T item in listEmps)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return temp;
        }
        public void Remove(int id)
        {
            foreach (T item in listEmps)
            {
                if (item.ID == id)
                {
                    listEmps.Remove(item);
                }
            }
            //listEmps.RemoveAt(id);
        }
    }
}
