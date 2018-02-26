using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2
{
    class TV:Product
    {
        private bool mblIs3D;

        public bool Is3D
        {
            get { return mblIs3D; }
            set { mblIs3D = value; }
        }
        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.Display());
            
            sb.AppendFormat("TV Type is 3D: {0}\n", this.Is3D);

            return sb.ToString();


        }
        
    }
}
