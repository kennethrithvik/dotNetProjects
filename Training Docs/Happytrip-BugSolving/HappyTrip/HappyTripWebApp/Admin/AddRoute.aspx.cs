using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class AddRoute : System.Web.UI.Page
    {
        RouteManager obj = new RouteManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Cities obj = new Cities();
                    List<City> cityList = obj.GetCities();

                    dpFromCity.Items.Add("None");
                    foreach (City c in cityList)
                    {
                        ListItem item = new ListItem(c.Name, c.CityId.ToString());
                        dpFromCity.Items.Add(item);
                    }
                    dpFromCity.DataBind();

                    dpToCity.Items.Add("None");
                    foreach (City c in cityList)
                    {
                        ListItem item = new ListItem(c.Name, c.CityId.ToString());
                        dpToCity.Items.Add(item);
                    }
                    dpToCity.DataBind();
                }
                catch (CityManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Route route = new Route();

                City fromcity = new City();
                if (dpFromCity.SelectedItem.Value != "None" && dpFromCity.SelectedItem.Value != "None")
                    fromcity.CityId = long.Parse(dpFromCity.SelectedItem.Value);
                fromcity.Name = dpFromCity.SelectedItem.Text;
                route.FromCity = fromcity;

                City tocity = new City();
                if (dpToCity.SelectedItem.Value != "None" && dpToCity.SelectedItem.Value != "None")
                    tocity.CityId = long.Parse(dpToCity.SelectedItem.Value);
                tocity.Name = dpToCity.SelectedItem.Text;
                route.ToCity = tocity;

                if (txtDistance.Text != "" && txtDistance.Text != null)
                    route.DistanceInKms = double.Parse(txtDistance.Text);

                route.IsActive = chkActive.Checked;
                if(obj.AddRoute(route))
                    lblError.Text = "Route Added Successfully";
                else
                    lblError.Text = "Unable to add Route";
            }
            catch (RouteManagerException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            dpFromCity.SelectedIndex = 0;
            dpToCity.SelectedIndex = 0;
            txtDistance.Text = "";
            chkActive.Checked = false;
            lblError.Text = "";
        }
    }
}