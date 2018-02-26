using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTripWebApp.Admin
{
    public partial class Add_Schedule : System.Web.UI.Page
    {
        int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();                   
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
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

            DropDownList1.Items.Add("0");
            DropDownList4.Items.Add("0");
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
            CityManager obj = new CityManager();
            try
            {
                City[] cityList = obj.GetCities();

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
            catch (CityManagerException e)
            {
                lblError.Text = e.Message;
            }


            Airlines objairline = new Airlines();
            try
            {
                List<Airline> airlinelist = objairline.GetAllAirlinesCollecction();

                dpAirlineName.Items.Add("None");
                foreach (Airline c in airlinelist)
                {
                    ListItem item = new ListItem(c.Name, c.Id.ToString());
                    dpAirlineName.Items.Add(item);
                }
                dpAirlineName.DataBind();
            }
            catch (AirlineManagerException e)
            {
                lblError.Text = e.Message;
            }
           
            var travelClassvalues = Enum.GetValues(typeof(TravelClass)).Cast<TravelClass>();
            Repeater1.DataSource = travelClassvalues;
            Repeater1.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ScheduleManager obj = new ScheduleManager();

            Schedule schedule = new Schedule();

            Route route = new Route();

            
            City fromcity = new City();
            if(dpFromCity.SelectedItem.Value != "None" && dpFromCity.SelectedItem.Value!= "none")
                fromcity.CityId = long.Parse(dpFromCity.SelectedItem.Value);
            fromcity.Name = dpFromCity.SelectedItem.Text;
            route.FromCity = fromcity;

            City tocity = new City();
            if (dpToCity.SelectedItem.Value != "None" && dpToCity.SelectedItem.Value != "none")
                tocity.CityId = long.Parse(dpToCity.SelectedItem.Value);
            tocity.Name = dpToCity.SelectedItem.Text;
            route.ToCity = tocity;

            schedule.RouteInfo = route;

            TimeSpan t1 = new TimeSpan(0, 0, 0);
            if (DropDownList4.SelectedItem.ToString() != "None" && DropDownList4.SelectedItem.ToString() != "none")
                t1 = TimeSpan.Parse(DropDownList4.SelectedItem.ToString() + ":" + DropDownList5.SelectedItem.ToString());

            TimeSpan t2 = new TimeSpan(0, 0, 0);
            if (DropDownList1.SelectedItem.ToString() != "None" && DropDownList1.SelectedItem.ToString() != "none") 
                TimeSpan.Parse(DropDownList1.SelectedItem.ToString() + ":" + DropDownList2.SelectedItem.ToString());

            total = int.Parse((t1 - t2).TotalMinutes.ToString());
            txtDuration.Text = total.ToString();

            Flight flight = new Flight();
            if (dpFlightName.SelectedItem != null && dpFlightName.SelectedItem.Text != "None")
                flight.ID = long.Parse(dpFlightName.SelectedItem.Value);
            if(dpFlightName.SelectedItem != null)
                flight.Name = dpFlightName.SelectedItem.Text;

            schedule.RouteInfo = route;
            schedule.FlightInfo = flight;

            TimeSpan tempT1;
            TimeSpan.TryParse(DropDownList1.SelectedItem.ToString() + ":" + DropDownList2.SelectedItem.ToString(), out tempT1);
            schedule.DepartureTime = tempT1;

            TimeSpan.TryParse(DropDownList4.SelectedItem.ToString() + ":" + DropDownList5.SelectedItem.ToString(), out tempT1);
            schedule.ArrivalTime = tempT1;
                
            schedule.DurationInMins = total;
            schedule.IsActive = chkStatus.Checked;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label lblclassname = (Label)item.FindControl("ClassName");
                TextBox txtcost = (TextBox)item.FindControl("txtCostPerTicket");

                if (txtcost != null || lblclassname != null)
                {
                    string classname = lblclassname.Text;
                    string val = txtcost.Text;

                    FlightCost fc = new FlightCost();
                    fc.Class = (TravelClass)Enum.Parse(typeof(TravelClass), classname);
                    fc.CostPerTicket = decimal.Parse(txtcost.Text);

                    schedule.AddFlightCost(fc);
                }
            }

            try
            {
                if (obj.AddSchedule(schedule))
                    lblError.Text = "Schedule Added Successfully";
                else
                    lblError.Text = "Unable to add schedule";
            }
            catch (ScheduleManagerException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void dpAirlineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpAirlineName.Text.Equals("None") == false)
            {
                dpFlightName.Items.Clear();
                FlightManager objairline = new FlightManager();
                try
                {
                    List<Flight> flightlist = objairline.GetFlightsForAirLine(int.Parse(dpAirlineName.SelectedValue));

                    dpFlightName.Items.Add("None");
                    foreach (Flight c in flightlist)
                    {
                        ListItem item = new ListItem(c.Name, c.ID.ToString());
                        dpFlightName.Items.Add(item);
                    }
                    dpFlightName.DataBind();
                }
                catch (FlightManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}