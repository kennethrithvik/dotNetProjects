using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.ServiceReference1;
using System.Data;

namespace Facebook
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
             ServiceReference1.FriendServiceSoapClient FC = new ServiceReference1.FriendServiceSoapClient();
             string Name = txtfriend.Text;
             String[] ds = FC.GetFriendList(Name);

                GridView1.DataSource = ds;

                GridView1.DataBind();
        }
    }
}