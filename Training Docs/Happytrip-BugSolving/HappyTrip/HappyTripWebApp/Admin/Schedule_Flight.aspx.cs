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
    public partial class Schedule_Flight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsGet();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater c = e.Item.FindControl("RepeaterInner") as Repeater;
        }

        protected void Repeater1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Schedule _flight = e.Item.DataItem as Schedule;
                Repeater innerDataList = e.Item.FindControl("dlFlightCost") as Repeater;
                innerDataList.DataSource = _flight.GetFlightCosts();
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

        private void ItemsGet()
        {
            // Read sample item info from XML document into a DataSet

            try
            {
                // Populate the repeater control with the Items DataSet
                ScheduleManager obj = new ScheduleManager();
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = obj.GetSchedules();
                objPds.AllowPaging = true;
                objPds.PageSize = 5;

                objPds.CurrentPageIndex = CurrentPage;

                lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of "
                  + objPds.PageCount.ToString();

                // Disable Prev or Next buttons if necessary
                commandPrevious.Enabled = !objPds.IsFirstPage;
                commandNext.Enabled = !objPds.IsLastPage;

                Repeater1.DataSource = objPds;
                Repeater1.DataBind();
            }
            catch (ScheduleManagerException ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label b = (Label)e.Item.FindControl("lblscheduleid");
            Response.Redirect("EditSchedule.aspx?scheduleid=" + b.Text);
        }

    }


 }