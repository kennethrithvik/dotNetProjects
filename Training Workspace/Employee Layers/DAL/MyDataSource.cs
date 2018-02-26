using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DAL
{
    public static class MyDataSource
    {
        internal static Dictionary<int, EntityLayer.Product>MyProductList;

        static MyDataSource()
        {
            MyProductList = new Dictionary<int, EntityLayer.Product>();
        }
    }
   
}
