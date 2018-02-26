using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.BusinessLayer.AirTravel;

namespace HappyTripWebApp.Admin
{
    public partial class EditAirline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcrAirlineName.Text.Length == 0)
                {
                    lblError.Text = "Airline Name Can't be Empty";
                    txtcrAirlineName.Focus();
                }
                else if (txtcrAirlineCode.Text.Length == 0)
                {
                    lblError.Text = "Airline Code Can't be Empty";
                    txtcrAirlineCode.Focus();
                }
                else if (txtcrAirlineLogoPath.Text.Length == 0)
                {
                    lblError.Text = "Airline Logo Path Can't be Empty";
                    txtcrAirlineLogoPath.Focus();
                }
                else
                {

                    string airlineCode = txtcrAirlineCode.Text;
                    string logoPath = txtcrAirlineLogoPath.Text;
                    string airlineName = txtcrAirlineName.Text;

                    sdsAirline.InsertParameters["AirlineName"].DefaultValue = airlineName;
                    sdsAirline.InsertParameters["AirlineCode"].DefaultValue = airlineCode;
                    sdsAirline.InsertParameters["AirlineLogo"].DefaultValue = logoPath;
                    sdsAirline.Insert();

                    lblError.Text = "Airlines Added Successfully";
                }
            }
            catch (AirlineManagerException ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtcrAirlineCode.Text = "";
            txtcrAirlineName.Text = "";
            txtcrAirlineLogoPath.Text = "";
            lblError.Text = "";
        }
    }
}