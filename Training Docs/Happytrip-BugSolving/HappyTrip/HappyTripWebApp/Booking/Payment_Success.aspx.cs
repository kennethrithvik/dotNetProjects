using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp.Booking
{
    public partial class Payment_Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Obtain the bookingObjects From Session
            if (!IsPostBack)
            {
                decimal TotalCost = 0;
                TravelBooking _travelBooking = null;
                FlightBooking flightbookingonward = null;
                FlightBooking flightbookingreturn = null;
                if (Session["TravelBooking"] != null)
                {
                    _travelBooking = (TravelBooking)Session["TravelBooking"];
                    flightbookingonward = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.OneWay);
                    flightbookingreturn = (FlightBooking)_travelBooking.GetBookingForTravel(TravelDirection.Return);
                }
                if (flightbookingonward != null)
                {
                    FlightBooking flightbooking = flightbookingonward;
                    int NoOfSeats = flightbooking.NoOfSeats;
                    lblHeaderDepart.Text = flightbooking.DateOfJourney.ToString("ddd, dd MMM, yyyy");
                    lblAdults.Text = NoOfSeats.ToString();

                    List<Passenger> lstPassenger = flightbooking.GetPassengers(); ;


                    rptrPassengerInfo.DataSource = lstPassenger;
                    rptrPassengerInfo.DataBind();

                    rptrOnwardFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                    rptrOnwardFlightInfo.DataBind();

                    TotalCost = flightbooking.TotalCost;

                    lblHeaderDateSeparator.Visible = false;


                    //Fill Contacts details

                    lblName.Text = flightbooking.Contact.ContactName;
                    lblAddressline1.Text = flightbooking.Contact.MobileNo;
                    lblState.Text = flightbooking.Contact.State;
                    lblCity.Text = flightbooking.Contact.City;
                    lblEmail.Text = flightbooking.Contact.Email;
                    lblMobno.Text = flightbooking.Contact.MobileNo;
                    lblPhno.Text = flightbooking.Contact.PhoneNo;

                    lblHeaderFromCity.Text = ((SearchInfo)Session["SearchInfo"]).FromCity.Name;
                    lblHeaderToCity.Text = ((SearchInfo)Session["SearchInfo"]).ToCity.Name;

                    lblOnwardTicketNo.Text = flightbooking.ReferenceNo;

                }

                if (flightbookingreturn != null)
                {
                    FlightBooking flightbooking = flightbookingreturn;
                    int NoOfSeats = flightbooking.NoOfSeats;
                    lblHeaderReturn.Text = flightbooking.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                    rptrReturnFlightInfo.DataSource = flightbooking.TravelScheduleInfo.GetSchedules();
                    rptrReturnFlightInfo.DataBind();

                    divReturn.Visible = true;

                    TotalCost = TotalCost + flightbooking.TotalCost;

                    lblHeaderDateSeparator.Visible = true;

                    pnlReturnTicketNo.Visible = true;
                    lblReturnTicketNo.Text = flightbooking.ReferenceNo;
                }

                
            }
            #endregion
        }
    }
}