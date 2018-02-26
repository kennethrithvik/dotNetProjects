using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    class Product
    {
        private static int sintProductCount;

        public static int ProductCount
        {
            get { return sintProductCount; }

        }
        public Product()
        {
            sintProductCount++; 
        }
        private int mintProductID;

        public int ProductID
        {
            get
            {
                return mintProductID;

            }
            set
            {
                if (value > 0)
                {
                    mintProductID = value;
                }
                else
                    throw new Exception("invalid ID");

            }
        }

        private string mstrName;

        public string Name
        {
            get { return mstrName; }
            set
            {
                if (value.Length > 3)
                    mstrName = value;
                else
                    throw new Exception("Length should be atleast 3");
            }
        }

        private DateTime mdtMfgDate;

        public DateTime MfgDate
        {
            get { return mdtMfgDate; }
            set {
                TimeSpan ts = DateTime.Now.Subtract(value);
                if(ts.Days<0||(ts.Days)/365>5)
                    throw new Exception("invalid date");
                else
                    mdtMfgDate = value; }
        }

        private int mintQuant;

        public int Quant
        {
            get { return mintQuant; }
            set
            {
                if (value>0&&value<100)
                    mintQuant = value;
                else
                    throw new Exception("Quantity should be from 1 to 99");
            }
        }


        public MRP mrp;

        public virtual string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Product ID: {0}\n", this.ProductID);
            sb.AppendFormat("Product Nmae: {0}\n", this.Name);
            sb.AppendFormat("Manufacturing Date: {0}\n", this.MfgDate.ToShortDateString());
            sb.AppendFormat("Quantity: {0}\n", this.Quant);
            sb.AppendFormat("Product price: {0}\n", this.mrp.GetGross()*this.Quant);
            
            return sb.ToString();
        

        }
    }
}
