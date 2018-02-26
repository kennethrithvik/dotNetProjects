using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class ManageFlights : System.Web.UI.Page
    {
        public int CurrentPage
        {
            get
            {
                // look for current page in ViewState
                object o = this.ViewState["_CurrentPage"];
                if (o == null)
                    return 0;   // default to showing the first page
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_CurrentPage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsGet();
            }
        }


        private void ItemsGet()
        {
            // Read sample item info from XML document into a DataSet
            try
            {
                // Populate the repeater control with the Items DataSet
              //  FlightManager _flightManger = new FlightManager();
                Flights _flightManger = new Flights();
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = _flightManger.GetFlightsCollectionForAirline();
                objPds.AllowPaging = true;
                objPds.PageSize = 3;

                objPds.CurrentPageIndex = CurrentPage;

                lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
                  + objPds.PageCount.ToString();

                // Disable Prev or Next buttons if necessary
                commandPrevious.Enabled = !objPds.IsFirstPage;
                commandNext.Enabled = !objPds.IsLastPage;

                dlFlight.DataSource = objPds;
                dlFlight.DataBind();
            }
            catch (FlightManagerException ex)
            {
                throw ex;
            }
        }

        protected void dlFlight_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Flight _flight = e.Item.DataItem as Flight;
                Repeater innerDataList = e.Item.FindControl("dlFlightClass") as Repeater;
                innerDataList.DataSource = _flight.GetClasses();
                innerDataList.DataBind();
            }
        }

        protected void commandPrevious_Click(object sender, EventArgs e)
        {
            // Set viewstate variable to the previous page
            CurrentPage -= 1;

            // Reload control
            ItemsGet();
        }

        protected void commandNext_Click(object sender, EventArgs e)
        {
            // Set viewstate variable to the next page
            CurrentPage += 1;

            // Reload control
            ItemsGet();
        }

        protected void dlFlight_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label b = (Label)e.Item.FindControl("lblflightid");
            Response.Redirect("EditFlight.aspx?flightid=" + b.Text);
        }
    }
}