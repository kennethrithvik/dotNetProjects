using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class EditFlight : System.Web.UI.Page
    {
        Flight flight;
        string flightid;

        public void BindData()
        {
            try
            {
                ddlAirLine.DataSource = new AirLineManager().GetAirLines();
                ddlAirLine.DataTextField = "Name";
                ddlAirLine.DataValueField = "Id";
                ddlAirLine.DataBind();

                flightid = Request.QueryString["flightid"].ToString();

                FlightManager obj = new FlightManager();
                flight = obj.GetFlight(int.Parse(flightid));

                FlightClass flightclass = new FlightClass();

                txtName.Text = flight.Name;
                ddlAirLine.SelectedValue = flight.AirlineForFlight.Id.ToString();
                GridView1.DataSource = flight.GetClasses();
                GridView1.DataBind();
            }
            
            catch (FlightManagerException ex)
            {
                throw ex;
            }
            catch (AirlineManagerException exc2)
            {
                throw exc2;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                lblError.Text = "Flight Name Can't be Empty";
                txtName.Focus();
            }
            else
            {
                try
                {
                    string flightName = txtName.Text;
                    int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
                    string airlinename = ddlAirLine.SelectedItem.Text;
                    flightid = Request.QueryString["flightid"].ToString();
                    Flight _flight = new Flight() { ID = int.Parse(flightid), Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };
                    FlightManager _flightManger = new FlightManager();

                    if (_flightManger.UpdateFlight(_flight))
                        lblError.Text = "Flight Updated";
                    else
                        lblError.Text = "Unable to updated Flight";
                }
                catch (FlightManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                if (((TextBox)row.FindControl("txtNoOfSeats")).Text.Length == 0)
                {
                    lblError.Text = "Seats Cannot be Empty";
                    ((TextBox)row.FindControl("txtNoOfSeats")).Focus();
                }
                else
                {
                    string txtClass = ((TextBox)row.FindControl("txtClass")).Text;
                    int txtNoOfSeats = Convert.ToInt32((((TextBox)row.FindControl("txtNoOfSeats")).Text.ToString()));

                    FlightClass _class = new FlightClass();
                    switch (txtClass)
                    {
                        case "Economy": _class.ClassInfo = TravelClass.Economy; break;
                        case "Business": _class.ClassInfo = TravelClass.Business; break;
                        default:
                            break;
                    }
                    _class.NoOfSeats = txtNoOfSeats;

                    FlightManager _flightManger = new FlightManager();

                    string flightName = txtName.Text;
                    int airlineid = int.Parse(ddlAirLine.SelectedItem.Value);
                    string airlinename = ddlAirLine.SelectedItem.Text;
                    flightid = Request.QueryString["flightid"].ToString();
                    Flight _flight = new Flight() { ID = int.Parse(flightid), Name = flightName, AirlineForFlight = new Airline() { Id = airlineid, Name = airlinename } };

                    _flightManger.UpdateFlightClass(_flight, _class);

                    e.Cancel = true;
                    GridView1.EditIndex = -1;
                    BindData();

                    lblError.Text = "Flight Seats Updated";
                }
            }
            catch (FlightManagerException ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddlAirLine.Items.Clear();
            BindData();
        }
    }
}