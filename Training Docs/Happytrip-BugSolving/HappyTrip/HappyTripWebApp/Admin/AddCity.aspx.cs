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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string CityName = txtCrCity.Text;

            State _state = new State();
            if(dpStateCity.SelectedItem.Value != "None" && dpStateCity.SelectedItem.Value != "none")
                _state.StateId = long.Parse(dpStateCity.SelectedItem.Value); 

            City _city = new City();
            _city.Name = CityName;
            _city.StateInfo = _state; 

            CityManager _cityManger = new CityManager();

            try
            {
                if (_cityManger.AddCity(_city))
                {
                    lblError.Text = "City Added Successfully";
                }
                else
                {
                    lblError.Text = "City already exists";
                }
            }
            catch (CityManagerException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        public void clear()
        {
            txtCrCity.Text = "";
            lblError.Text = "";
            dpStateCity.Items.Clear();

            CityManager obj = new CityManager();
            List<State> stateList = obj.GetStates();

            dpStateCity.Items.Add("None");
            foreach (State s in stateList)
            {
                ListItem item = new ListItem(s.Name, s.StateId.ToString());
                dpStateCity.Items.Add(item);
            }
            dpStateCity.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}