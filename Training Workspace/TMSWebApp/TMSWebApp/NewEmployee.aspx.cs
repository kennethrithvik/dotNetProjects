using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMSWebApp
{
    public partial class NewEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RangeValidator1_Load(object sender, EventArgs e)
        {
            RangeValidator1.MaximumValue = DateTime.Now.ToShortDateString();
        }
    }
}