using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                #region Obtain the bookingObjects From Session
                if (!IsPostBack)
                {
                    decimal TotalCost = 0;
                    TravelBooking _travelBooking = null;
                    FlightBooking flightbookingonward = null;
                    FlightBooking flightbookingreturn = null;
                    if (Session["travelbooking"] != null)
                    {
                        _travelBooking = (TravelBooking)Session["travelbooking"];
                        flightbookingonward = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.OneWay);
                        flightbookingreturn = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.Return);
                    }
                    if (flightbookingonward != null)
                    {
                        FlightBooking flightbooking = flightbookingonward;
                        int NoOfSeats = flightbooking.NoOfSeats;

                        List<Passenger> lstPassenger = flightbooking.GetPassengers(); ;


                        rptrPassengerInfo.DataSource = lstPassenger;
                        rptrPassengerInfo.DataBind();

                        rptrOnwardFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                        rptrOnwardFlightInfo.DataBind();

                        TotalCost = flightbooking.TotalCost;

                        lblHeaderFromCity.Text = ((SearchInfo)Session["SearchInfo"]).FromCity.Name;
                        lblHeaderToCity.Text = ((SearchInfo)Session["SearchInfo"]).ToCity.Name;
                        lblAdults.Text = flightbookingonward.NoOfSeats.ToString() + " Seats";

                        lblHeaderDepart.Text = flightbookingonward.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                        


                        lblHeaderDateSeparator.Visible = false;
                        if (_travelBooking.IsReturnAvailable())
                            lblHeaderDateSeparator.Visible = true;

                        //Fill Contacts details

                        lblName.Text = flightbooking.Contact.ContactName;
                        lblAddressline1.Text = flightbooking.Contact.MobileNo;
                        lblState.Text = flightbooking.Contact.State;
                        lblCity.Text = flightbooking.Contact.City;
                        lblEmail.Text = flightbooking.Contact.Email;
                        lblMobno.Text = flightbooking.Contact.MobileNo;
                        lblPhno.Text = flightbooking.Contact.PhoneNo;


                    }

                    if (flightbookingreturn != null)
                    {
                        FlightBooking flightbooking = flightbookingreturn;
                        int NoOfSeats = flightbooking.NoOfSeats;

                        rptrReturnFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                        rptrReturnFlightInfo.DataBind();

                        divReturn.Visible = true;

                        TotalCost = TotalCost + flightbooking.TotalCost;

                        lblHeaderReturn.Text = flightbookingreturn.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                    }

                    lblTotalPrice.Text = TotalCost.ToString();
                }
                #endregion
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/booking/Payment_Screen.aspx");
        }
    }
}