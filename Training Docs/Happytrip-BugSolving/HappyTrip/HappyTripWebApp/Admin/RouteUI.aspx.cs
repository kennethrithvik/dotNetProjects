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
    public partial class RouteUI : System.Web.UI.Page
    {
        RouteManager obj = new RouteManager();

        private void BindData()
        {
            Routes obj1 = new Routes();
            try
            {
                //Get routes 
                List<Route> routes = obj1.GetRoutes();

                #region Populate into the data table to bind to grid
                DataTable dt = new DataTable("Routes");
                dt.Columns.Add("RouteId", typeof(long));
                dt.Columns.Add("FromCityName", typeof(string));
                dt.Columns.Add("ToCityName", typeof(string));
                dt.Columns.Add("DistanceInKms", typeof(double));
                dt.Columns.Add("Status", typeof(bool));

                foreach(Route route in routes)
                {
                    DataRow dr = dt.NewRow();
                    dr["RouteId"] = route.ID;
                    dr["FromCityName"] = route.FromCity.Name;
                    dr["ToCityName"] = route.ToCity.Name;
                    dr["DistanceInKms"] = route.DistanceInKms;
                    dr["Status"] = route.IsActive;

                    dt.Rows.Add(dr);
                }
                #endregion

                GridView1.DataSource = dt;

                GridView1.DataBind();
            }
            catch (RouteManagerException ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
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
            GridViewRow row = GridView1.Rows[e.RowIndex];

            if (((TextBox)(row.Cells[3].Controls[0])).Text.Length == 0)
            {
                lblError.Text = "Distance in Kms Can't be Empty";
                ((TextBox)(row.Cells[3].Controls[0])).Focus();
            }
            else
            {
                try
                {
                    Route route = new Route();
                    route.ID = long.Parse((row.Cells[0].Text));
                    route.DistanceInKms = long.Parse(((TextBox)(row.Cells[3].Controls[0])).Text);
                    route.IsActive = ((CheckBox)(row.Cells[4].Controls[0])).Checked;

                    if(obj.UpdateRoute(route))
                        lblError.Text = "Route Updated";
                    else
                        lblError.Text = "Route Not Updated";

                    e.Cancel = true;
                    GridView1.EditIndex = -1;
                    BindData();

                    
                }
                catch (RouteManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}