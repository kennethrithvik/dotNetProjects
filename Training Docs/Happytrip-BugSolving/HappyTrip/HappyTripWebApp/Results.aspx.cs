using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer.Search;
using System.Data;
using HappyTrip.Model.Entities.Transaction;
using System.Web.Security;

namespace HappyTripWebApp
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Get all the information from query string
                    long FromCityId = Convert.ToInt64(Request.QueryString["fromid"].ToString());
                    long ToCityId = Convert.ToInt64(Request.QueryString["toid"].ToString());
                    string FromCityName = Request.QueryString["fromCityName"].ToString();
                    string ToCityName = Request.QueryString["toCityName"].ToString();
                    string flightclass = Request.QueryString["class"].ToString();
                    int td = Convert.ToInt16(Request.QueryString["td"].ToString());
                    string adults = Request.QueryString["adults"].ToString();

                    //Display the header information
                    lblAdults.Text = adults;
                    hdnTravelDirection.Value = td.ToString();
                    if (Request.QueryString["depart_date"] != null)
                        lblHeaderDepart.Text = Convert.ToDateTime(Request.QueryString["depart_date"]).ToString("ddd, dd MMM, yyyy");

                    if (Request.QueryString["return_date"] != null)
                        lblHeaderReturn.Text = Convert.ToDateTime(Request.QueryString["return_date"]).ToString("ddd, dd MMM, yyyy");

                    TravelDirection traveldirection = (TravelDirection)td;

                    City fromcity = new City();
                    fromcity.CityId = FromCityId;
                    fromcity.Name = FromCityName;

                    City tocity = new City();
                    tocity.CityId = ToCityId;
                    tocity.Name = ToCityName;

                    SearchInfo searchinfo = new SearchInfo();
                    if (Request.QueryString["depart_date"] != null)
                        searchinfo.OnwardDateOfJourney = Convert.ToDateTime(Request.QueryString["depart_date"]);

                    if (Request.QueryString["return_date"] != null)
                        searchinfo.ReturnDateOfJourney = Convert.ToDateTime(Request.QueryString["return_date"]);
                    TravelClass travelclass = (TravelClass)Enum.Parse(typeof(TravelClass), flightclass);
                    searchinfo.FromCity = fromcity;
                    searchinfo.ToCity = tocity;
                    searchinfo.Class = travelclass;
                    searchinfo.Direction = traveldirection;

                    //Contact the search manager and get all the schedules as a search log
                    ISearchManager searchmanager = SearchManagerFactory.GetInstance().Create();
                    SearchLog searchlog = searchmanager.SearchForFlights(searchinfo);

                    SearchResult searchresult = searchlog.GetSearchResult(TravelDirection.OneWay);

                    List<TravelSchedule> lstTravelSchedule = searchresult.GetTravelSchedules();
                    dlOuterOnward.DataSource = lstTravelSchedule;
                    dlOuterOnward.DataBind();

                    Session["flightbookingonwardresults"] = lstTravelSchedule;
                    Session["SearchInfo"] = searchinfo;

                    if (lstTravelSchedule.Count > 0)
                    {

                        lblOneWayFromCity.Text = lblHeaderFromCity.Text = searchinfo.FromCity.Name;
                        lblOneWayToCity.Text = lblHeaderToCity.Text = searchinfo.ToCity.Name;
                    }

                    if (traveldirection == TravelDirection.Return)
                    {
                        SearchResult searchresultreturn = searchlog.GetSearchResult(TravelDirection.Return);

                        List<TravelSchedule> lstTravelScheduleReturn = searchresultreturn.GetTravelSchedules();
                        dlOuterReturn.DataSource = lstTravelScheduleReturn;
                        dlOuterReturn.DataBind();

                        Session["flightbookingreturnresults"] = lstTravelScheduleReturn;

                        if (lstTravelScheduleReturn.Count > 0)
                        {
                            lblReturnFromCity.Text = searchinfo.ToCity.Name;
                            lblReturnToCity.Text = searchinfo.FromCity.Name;
                        }
                    }
                    else
                    {
                        outbound_div.Style.Add("width", "70%");
                        return_div.Visible = false;
                        lblHeaderReturn.Visible = false;
                        lblHeaderDateSeparator.Visible = false;
                    }
                }
                catch (Exception ex)
                {

                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }

        }

        protected void dlOuterOnward_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TravelSchedule drv = e.Item.DataItem as TravelSchedule;
                Repeater innerDataList = e.Item.FindControl("dlInnerOnward") as Repeater;
                innerDataList.DataSource = drv.GetSchedules();
                innerDataList.DataBind();
            }
        }

        protected void dlOuterReturn_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TravelSchedule drv = e.Item.DataItem as TravelSchedule;

                Repeater innerDataList = e.Item.FindControl("dlInnerReturn") as Repeater;
                innerDataList.DataSource = drv.GetSchedules();
                innerDataList.DataBind();
            }
        }

        protected static string GetText(int ItemIndex, object dataItem)
        {
            if (ItemIndex == 0)
                return dataItem.ToString();

            return string.Empty;
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            int adults = Convert.ToInt32(Request.QueryString["adults"].ToString());

            int td = Convert.ToInt16(Request.QueryString["td"].ToString());
            TravelDirection traveldirection = (TravelDirection)td;

            List<string> onwardids = new List<string>();
            for (int i = 0; i < hdnScheduleOnwardSelectedId.Value.Split('|').Length; i++)
                onwardids.Add(hdnScheduleOnwardSelectedId.Value.Split('|')[i].ToString());

            List<TravelSchedule> lstTravelSchedule = (List<TravelSchedule>)Session["flightbookingonwardresults"];
            List<Schedule> resultonward = (from t in lstTravelSchedule.SelectMany(schedule => schedule.GetSchedules()).Distinct<Schedule>()
                                                 where onwardids.Contains(t.ID.ToString())
                                                 select t).ToList();

            TravelSchedule objOnwardSchedule = new TravelSchedule();
            decimal OnwardCostPerTicket = 0;
            decimal OnwardTotalCost = 0;
            foreach(Schedule schedule in resultonward)
            {
                objOnwardSchedule.AddSchedule(schedule);
                OnwardCostPerTicket = OnwardCostPerTicket + schedule.GetFlightCosts().FirstOrDefault().CostPerTicket;
            }


            OnwardTotalCost = OnwardCostPerTicket * adults;

            FlightBooking flightbookingonward = new FlightBooking();
            flightbookingonward.NoOfSeats = adults;
            flightbookingonward.BookingType = BookingTypes.Flight;
            FlightClass Class = new FlightClass();
            Class.ClassInfo = (TravelClass)Enum.Parse(typeof(TravelClass), Request.QueryString["class"]);
            flightbookingonward.Class = Class;
            flightbookingonward.TravelScheduleInfo = objOnwardSchedule;
            flightbookingonward.DateOfJourney = Convert.ToDateTime(Request.QueryString["depart_date"]);
            flightbookingonward.TotalCost = OnwardTotalCost;

            if (Membership.GetUser() != null)
            {
                flightbookingonward.UserName = Membership.GetUser().UserName;
            }
            else
                flightbookingonward.UserName = "Anonymous";



            TravelBooking travelbooking = new TravelBooking();
            travelbooking.AddBookingForTravel(TravelDirection.OneWay, flightbookingonward);

            if (traveldirection == TravelDirection.Return)
            {
                List<string> retunrids = new List<string>();
                for (int i = 0; i < hdnScheduleReturnSelectedId.Value.Split('|').Length; i++)
                    retunrids.Add(hdnScheduleReturnSelectedId.Value.Split('|')[i].ToString());

                List<TravelSchedule> lstTravelScheduleReturn = (List<TravelSchedule>)Session["flightbookingreturnresults"];
                List<Schedule> resultreturn = (from t in lstTravelScheduleReturn.SelectMany(schedule => schedule.GetSchedules())
                                               where retunrids.Contains(t.ID.ToString())
                                               select t).ToList();

                TravelSchedule objReturnSchedule = new TravelSchedule();
                decimal ReturnTotalCost = 0;
                decimal ReturnCostPerTicket = 0;
                foreach (Schedule schedule in resultreturn)
                {
                    objReturnSchedule.AddSchedule(schedule);
                    ReturnCostPerTicket = ReturnCostPerTicket + schedule.GetFlightCosts().FirstOrDefault().CostPerTicket;
                }
                ReturnTotalCost = ReturnCostPerTicket * adults;

                FlightBooking flightbookingreturn = new FlightBooking();
                flightbookingreturn.NoOfSeats = adults;

                flightbookingreturn.BookingType = BookingTypes.Flight;
                FlightClass ReturnClass = new FlightClass();
                ReturnClass.ClassInfo = (TravelClass)Enum.Parse(typeof(TravelClass), Request.QueryString["class"]);
                flightbookingreturn.Class = Class;

                flightbookingreturn.TravelScheduleInfo = objReturnSchedule;
                flightbookingreturn.DateOfJourney = Convert.ToDateTime(Request.QueryString["return_date"]);
                flightbookingreturn.TotalCost = ReturnTotalCost;

                if (Membership.GetUser() != null)
                {
                    flightbookingreturn.UserName = Membership.GetUser().UserName;
                }
                else
                    flightbookingreturn.UserName = "Anonymous";

                
                travelbooking.AddBookingForTravel(TravelDirection.Return, flightbookingreturn);
            }

            Session["travelbooking"] = travelbooking;

            Response.Redirect("~/booking/passengers.aspx");
        }
    }
}