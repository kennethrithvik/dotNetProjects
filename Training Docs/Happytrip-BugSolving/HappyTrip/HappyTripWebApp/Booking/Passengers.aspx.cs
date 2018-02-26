using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Transaction;
using HappyTrip.Model.Entities.AirTravel;
using System.Web.Security;
using HappyTrip.Model.Entities.UserAccount;

namespace HappyTripWebApp
{
    public partial class Passengers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal TotalCost = 0;
                if (Session["travelbooking"] != null)
                {
                    TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];
                    FlightBooking bookingoneway =  (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);
                    int NoOfSeats = bookingoneway.NoOfSeats;

                    List<Passenger> lstPassenger = new List<Passenger>();
                    for (int i = 0; i < NoOfSeats; i++)
                    {
                        lstPassenger.Add(new Passenger { Name = string.Empty, Gender = ' ' });
                    }

                    rptrPassengerInfo.DataSource = lstPassenger;
                    rptrPassengerInfo.DataBind();

                    rptrOnwardFlightInfo.DataSource = bookingoneway.TravelScheduleInfo.GetSchedules();
                    rptrOnwardFlightInfo.DataBind();

                    TotalCost = bookingoneway.TotalCost;


                    lblHeaderFromCity.Text = ((SearchInfo)Session["SearchInfo"]).FromCity.Name;
                    lblHeaderToCity.Text = ((SearchInfo)Session["SearchInfo"]).ToCity.Name;
                    lblAdults.Text = bookingoneway.NoOfSeats.ToString() + " Seats";

                    lblHeaderDepart.Text = bookingoneway.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                    lblHeaderDateSeparator.Visible = false;

                    if (Membership.GetUser() != null)
                    {
                        ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());

                        txtName.Text = com.Personal.FullName;
                        txtAddress.Text = com.Contact.Address;
                        txtCity.Text = com.Contact.City;
                        txtState.Text = com.Contact.State;
                        txtMobile.Text = com.Contact.MobileNo;
                        txtEmailId.Text = com.Contact.Email;
                    }

                    if (travelbooking.IsReturnAvailable())
                    {
                        FlightBooking bookingreturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);

                        rptrReturnFlightInfo.DataSource = bookingreturn.TravelScheduleInfo.GetSchedules();
                        rptrReturnFlightInfo.DataBind();

                        divReturn.Visible = true;

                        TotalCost = TotalCost + bookingreturn.TotalCost;

                        lblHeaderReturn.Text = bookingreturn.DateOfJourney.ToString("ddd, dd MMM, yyyy");

                        lblHeaderDateSeparator.Visible = true;

                    }
                }

                lblTotalPrice.Text = TotalCost.ToString();
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (Session["travelbooking"] != null)
            {
                TravelBooking travelbooking = (TravelBooking)Session["travelbooking"];

                FlightBooking travelbookingoneway =  (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.OneWay);

                foreach (RepeaterItem item in rptrPassengerInfo.Items)
                {
                    TextBox Name = (TextBox)item.FindControl("AdultFname");
                    DropDownList Gender = (DropDownList)item.FindControl("ddlGender");
                    TextBox DOB = (TextBox)item.FindControl("txtDOB");

                    Passenger passenger = new Passenger { Name = Name.Text, DateOfBirth = Convert.ToDateTime(DOB.Text), Gender = Gender.SelectedItem.Value.ToCharArray()[0] };
                    travelbookingoneway.AddPassenger(passenger);
                }

                BookingContact bookingcontact = new BookingContact();
                bookingcontact.Address = txtAddress.Text;
                bookingcontact.City = txtCity.Text;
                bookingcontact.ContactName = txtName.Text;
                bookingcontact.Email = txtEmailId.Text;
                bookingcontact.MobileNo = txtMobile.Text;
                bookingcontact.PhoneNo = txtPhoneNumber.Text;
                bookingcontact.State = txtState.Text;

                travelbookingoneway.Contact = bookingcontact;
                travelbooking.AddBookingForTravel(TravelDirection.OneWay, travelbookingoneway);

                if (travelbooking.IsReturnAvailable())
                {
                    FlightBooking TravelBookingReturn = (FlightBooking)travelbooking.GetBookingForTravel(TravelDirection.Return);
                    foreach (var passenger in travelbookingoneway.GetPassengers())
                    {
                        TravelBookingReturn.AddPassenger(passenger);
                    }
                    TravelBookingReturn.Contact = bookingcontact;
                    travelbooking.AddBookingForTravel(TravelDirection.Return, TravelBookingReturn);
                }

                Session["travelbooking"] = travelbooking;
            }

            Response.Redirect("~/booking/confirmation.aspx");
        }
    }
}