using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using System.Data;

namespace HappyTripWebApp.Admin
{
    public partial class EditSchedule : System.Web.UI.Page
    {
        Schedule schedule;
        int total;
        long scheduleId;

        public void BindData()
        {

            scheduleId = Convert.ToInt64(Request.QueryString["scheduleid"]);
            ScheduleManager obj = new ScheduleManager();

            try
            {
                GridView1.DataSource = obj.GetFlightCostsForSchedule(scheduleId);
                GridView1.DataBind();
            }
            catch (ScheduleManagerException ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
                txtDuration.Enabled = false;

                scheduleId = Convert.ToInt64(Request.QueryString["scheduleid"]);

                try
                {
                    ScheduleManager obj = new ScheduleManager();
                    schedule = obj.GetSchedule(scheduleId);

                    dpFromCity.SelectedValue = schedule.RouteInfo.FromCity.CityId.ToString();
                    dpToCity.SelectedValue = schedule.RouteInfo.ToCity.CityId.ToString();
                    txtDuration.Text = schedule.DurationInMins.ToString();
                    TimeSpan dptime = schedule.DepartureTime;
                    DropDownList1.SelectedValue = dptime.Hours.ToString();
                    DropDownList2.SelectedValue = dptime.Minutes.ToString();
                    TimeSpan dpMinutes = schedule.ArrivalTime;
                    DropDownList4.SelectedValue = dpMinutes.Hours.ToString();
                    DropDownList5.SelectedValue = dpMinutes.Hours.ToString();

                    dpAirlineName.SelectedValue = schedule.FlightInfo.AirlineForFlight.Id.ToString();
                    ListItem item = new ListItem(schedule.FlightInfo.Name.ToString(), schedule.FlightInfo.ID.ToString());
                    dpFlightName.Items.Add(item);
                    chkStatus.Checked = schedule.IsActive;

                    BindData();
                    
                }
                catch (ScheduleManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        private void clear()
        {
            dpFromCity.Items.Clear();
            dpToCity.Items.Clear();
            dpAirlineName.Items.Clear();
            dpFlightName.Items.Clear();
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();

            for (int i = 1; i <= 24; i++)
            {
                DropDownList1.Items.Add(i.ToString());
                DropDownList4.Items.Add(i.ToString());
            }
            DropDownList1.DataBind();
            DropDownList4.DataBind();

            for (int i = 0; i <= 59; i++)
            {
                DropDownList2.Items.Add(i.ToString());
                DropDownList5.Items.Add(i.ToString());
            }
            DropDownList2.DataBind();
            DropDownList5.DataBind();

            txtDuration.Enabled = false;

            txtDuration.Text = "";
            chkStatus.Checked = false;

            try
            {
                CityManager obj = new CityManager();
                City[] cityList = obj.GetCities();

                foreach (City c in cityList)
                {
                    ListItem item = new ListItem(c.Name.Trim(), c.CityId.ToString());
                    dpFromCity.Items.Add(item);
                }
                dpFromCity.DataBind();


                foreach (City c in cityList)
                {
                    ListItem item = new ListItem(c.Name, c.CityId.ToString());
                    dpToCity.Items.Add(item);
                }
                dpToCity.DataBind();

                AirLineManager objairline = new AirLineManager();
				Airline[] airlinelist = objairline.GetAirLines();

                foreach (Airline c in airlinelist)
                {
                    ListItem item = new ListItem(c.Name, c.Id.ToString());
                    dpAirlineName.Items.Add(item);
                }
                dpAirlineName.DataBind();
            }
            catch (CityManagerException ex)
            {
                throw ex;
            }
            catch (AirlineManagerException exc)
            {
                throw exc;
            }
        }

        
        protected void dpAirlineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dpFlightName.Items.Clear();
                FlightManager objairline = new FlightManager();
                List<Flight> flightlist = objairline.GetFlightsForAirLine(int.Parse(dpAirlineName.SelectedValue));

                foreach (Flight c in flightlist)
                {
                    ListItem item = new ListItem(c.Name, c.ID.ToString());
                    dpFlightName.Items.Add(item);
                }
                dpFlightName.DataBind();
            }
            catch (FlightManagerException exc)
            {
                throw exc;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Schedule _flight = e.Item.DataItem as Schedule;
                Repeater innerDataList = e.Item.FindControl("dlFlightCost") as Repeater;
                innerDataList.DataSource = _flight.GetFlightCosts();
                innerDataList.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater c = e.Item.FindControl("RepeaterInner") as Repeater;
            
        }

        

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Home.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Route route = new Route();
                ScheduleManager obj = new ScheduleManager();

                Schedule schedule = new Schedule();

                City fromcity = new City();
                fromcity.CityId = long.Parse(dpFromCity.SelectedItem.Value);
                fromcity.Name = dpFromCity.SelectedItem.Text;
                route.FromCity = fromcity;

                City tocity = new City();
                tocity.CityId = long.Parse(dpToCity.SelectedItem.Value);
                tocity.Name = dpToCity.SelectedItem.Text;
                route.ToCity = tocity;

                schedule.RouteInfo = route;
                
                TimeSpan t1 = TimeSpan.Parse(DropDownList4.SelectedItem.ToString() + ":" + DropDownList5.SelectedItem.ToString());
                TimeSpan t2 = TimeSpan.Parse(DropDownList1.SelectedItem.ToString() + ":" + DropDownList2.SelectedItem.ToString());
                total = int.Parse((t1 - t2).TotalMinutes.ToString());
                txtDuration.Text = total.ToString();


                Flight flight = new Flight();
                flight.ID = long.Parse(dpFlightName.SelectedItem.Value);
                flight.Name = dpFlightName.SelectedItem.Text;

                scheduleId = Convert.ToInt64(Request.QueryString["scheduleid"]);
                schedule.ID = scheduleId;
                schedule.RouteInfo = route;
                schedule.FlightInfo = flight;
                schedule.DepartureTime = TimeSpan.Parse(DropDownList1.SelectedItem.ToString() + ":" + DropDownList2.SelectedItem.ToString());
                schedule.ArrivalTime = TimeSpan.Parse(DropDownList4.SelectedItem.ToString() + ":" + DropDownList5.SelectedItem.ToString());
                schedule.DurationInMins = total;
                schedule.IsActive = chkStatus.Checked;

                if(obj.UpdateSchedule(schedule))
                    lblError.Text = "Schedule Saved Successfully";
                else
                    lblError.Text = "Schedule Not Saved";
                
            }
            catch (ScheduleManagerException ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                if (((TextBox)row.FindControl("txtCost")).Text.Length == 0)
                {
                    lblError.Text = "Cost Cannot be Empty";
                    ((TextBox)row.FindControl("txtCost")).Focus();
                }
                else
                {

                    string txtClass = ((TextBox)row.FindControl("txtClass")).Text;
                    int txtCost = Convert.ToInt32((((TextBox)row.FindControl("txtCost")).Text.ToString()));
                    FlightCost _class = new FlightCost();
                    switch (txtClass)
                    {
                        case "Economy": _class.Class = TravelClass.Economy; break;
                        case "Business": _class.Class = TravelClass.Business; break;
                        default:
                            break;
                    }
                    _class.CostPerTicket = txtCost;

                    ScheduleManager obj = new ScheduleManager();
                    Schedule schedule = new Schedule();
                    Route route = new Route();
                    City fromcity = new City();
                    
                    fromcity.CityId = long.Parse(dpFromCity.SelectedItem.Value);
                    fromcity.Name = dpFromCity.SelectedItem.Text;
                    route.FromCity = fromcity;

                    City tocity = new City();
                    tocity.CityId = long.Parse(dpToCity.SelectedItem.Value);
                    tocity.Name = dpToCity.SelectedItem.Text;
                    route.ToCity = tocity;

                    Flight flight = new Flight();
                    flight.ID = long.Parse(dpFlightName.SelectedItem.Value);
                    flight.Name = dpFlightName.SelectedItem.Text;

                    scheduleId = Convert.ToInt64(Request.QueryString["scheduleid"]);
                    schedule.ID = scheduleId;
                    schedule.RouteInfo = route;
                    schedule.FlightInfo = flight;

                    obj.UpdateScheduleFlightCost(schedule, _class);

                    e.Cancel = true;
                    GridView1.EditIndex = -1;
                    BindData();

                    lblError.Text = "Flight Cost Updated";
                }
            }
            catch (ScheduleManagerException ex)
            {
                throw ex;
            }
        }
    }
}