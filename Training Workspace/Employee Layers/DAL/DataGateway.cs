using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataGateway<T>
    {
        List<T> GetProducts();
        T GetByID(int ID);
        bool Add(T prd);
        bool Edit(T prd);
        bool Remove(int id);
        List<T> GetByName(string na);
        bool IDExists(int id);
    }

    public class DataGateway //: IDataGateway
    {
        public List<EntityLayer.Product> GetProducts()
        {
            return MyDataSource.MyProductList.Values.ToList();
        }

        public EntityLayer.Product GetProductByID(int ID)
        {
            return MyDataSource.MyProductList[ID];
        }

        public bool AddProduct(EntityLayer.Product prd)
        {
            MyDataSource.MyProductList.Add(prd.ProductID,prd);
            return true;
        }

        public bool EditProduct(EntityLayer.Product prd)
        {
            EntityLayer.Product p = GetProductByID(prd.ProductID);
            p.Name = prd.Name;
            return true;
        }

        public bool RemoveProduct(int id)
        {
            MyDataSource.MyProductList.Remove(id);
            return true;
        }

        public List<EntityLayer.Product> GetByProductName(string na)
        {
            return null;

        }

        public bool ProductIDExists(int id)
        {
            if (MyDataSource.MyProductList.ContainsKey(id))
                return true;
            return false;
        }
    }
}
