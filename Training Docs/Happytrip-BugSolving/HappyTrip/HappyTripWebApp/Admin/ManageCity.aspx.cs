using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.Common;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class ManageCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            try
            {
                CityManager _cityManger = new CityManager();
                grdCity.DataSource = _cityManger.GetCities();
                grdCity.DataBind();
            }
            catch (CityManagerException ex)
            {
                throw ex;
            }
        }

        protected void grdCity_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCity.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void grdCity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdCity.Rows[e.RowIndex];

            TextBox txtState = (TextBox)row.FindControl("txtState");
            TextBox txtCityName = (TextBox)row.FindControl("txtCityName");

            if (txtCityName.Text.Length == 0)
            {
                lblError.Text = "City Name Can't be Empty";
                txtCityName.Focus();
            }
            else
            {
                int cityId = Int32.Parse(grdCity.DataKeys[e.RowIndex].Value.ToString());

                string CityName = txtCityName.Text;
                string StateName = txtState.Text;

                City _city = new City()
                {
                    CityId = cityId,
                    Name = CityName,
                    StateInfo = new State()
                    {
                        Name = StateName
                    }
                };

                try
                {
                    CityManager _cityManger = new CityManager();

                    if (_cityManger.UpdateCity(_city))
                    {
                        lblError.Text = "City Updated Successfully";
                    }
                    else
                    {
                        lblError.Text = "City already exists";
                    }
                    grdCity.EditIndex = -1;
                    BindData();
                }
                catch (CityManagerException ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void grdCity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            grdCity.EditIndex = -1;
            BindData();
        }

        protected void grdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCity.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}