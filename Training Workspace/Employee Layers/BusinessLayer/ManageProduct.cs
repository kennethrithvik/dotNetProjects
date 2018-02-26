using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BusinessLayer
{
    public class ManageProduct
    {
        DAL.DataGateway mydata;

        public ManageProduct()
        {
                mydata= new DAL.DataGateway();
        }
        public bool AddProduct(EntityLayer.Product pr)
        {
            if (mydata.ProductIDExists(pr.ProductID))
            {
                throw new ProductDuplicateIDException("Duplicate Product ID");
            }
            else
            {
                return mydata.AddProduct(pr);
            }
        }

        public List<EntityLayer.Product> GetProducts()
        {
            return mydata.GetProducts();
        }
    }
}
