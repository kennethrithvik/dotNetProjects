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
    public partial class AddFlight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ddlAirLine.Items.Add("None");
                    ddlAirLine.DataSource = new AirLineManager().GetAirLines();
                    ddlAirLine.DataTextField = "Name";
                    ddlAirLine.DataValueField = "Id";
                    ddlAirLine.DataBind();
                }             
                catch (AirlineManagerException ex)
                {
                    lblError.Text = ex.Message;
                }

                var travelClassvalues = Enum.GetValues(typeof(TravelClass)).Cast<TravelClass>();
                dlClass.DataSource = travelClassvalues;
                dlClass.DataBind();
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            txtName.Text = "";
            try
            {
                ddlAirLine.Items.Clear();
                ddlAirLine.Items.Add("None");
                ddlAirLine.DataSource = new AirLineManager().GetAirLines();
                ddlAirLine.DataTextField = "Name";
                ddlAirLine.DataValueField = "Id";
                ddlAirLine.DataBind();

                foreach (RepeaterItem item in dlClass.Items)
                {
                    TextBox txtNoOfSeats = (TextBox)item.FindControl("txtNoOfSeats");
                    txtNoOfSeats.Text = "0";
                }
            }
            catch (AirlineManagerException exc)
            {
                lblError.Text = exc.Message;
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            string flightName = txtName.Text;
            int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
            string airlinename = ddlAirLine.SelectedItem.Text;
            Flight _flight = new Flight() { Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };
            FlightManager _flightManger = new FlightManager();

            try
            {
                foreach (RepeaterItem item in dlClass.Items)
                {
                    TextBox txtNoOfSeats = (TextBox)item.FindControl("txtNoOfSeats");
                    Label lblClass = (Label)item.FindControl("lblClass");

                    if (txtNoOfSeats.Text.Length == 0)
                    {
                        txtNoOfSeats.Focus();
                        lblError.Text = "No of Seats Cannot be Empty";
                        break;
                    }
                    else
                    {
                        if (txtNoOfSeats != null)
                        {
                            TravelClass travelClass = (TravelClass)Enum.Parse(typeof(TravelClass), lblClass.Text.Trim());
                            int NoOfSeats = int.Parse(txtNoOfSeats.Text);
                            FlightClass _class = new FlightClass() { ClassInfo = travelClass, NoOfSeats = NoOfSeats };
                            _flight.AddClass(_class);
                        }
                    }
                }
                if (_flightManger.AddFlight(_flight) == false)
                {
                    lblError.Text = "Flight Name already exists";
                }
                else
                {
                    lblError.Text = "Flight Added Successfully";
                }
            }
            catch (FlightManagerException exc)
            {
                lblError.Text = exc.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }
    }
}