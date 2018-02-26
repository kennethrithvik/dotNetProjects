﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign1
{
    class Mobile:Product
    {
        private bool mblIs4G;

        public bool Is4G
        {
            get { return mblIs4G; }
            set { mblIs4G = value; }
        }
        public override string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.Display());

            sb.AppendFormat("Mobile Type is 4G: {0}\n", this.Is4G);

            return sb.ToString();


        }
    }
}