using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductDuplicateIDException:SystemException
    {
        public ProductDuplicateIDException(string msg):base(msg)
        {
              
        }
    }
}
