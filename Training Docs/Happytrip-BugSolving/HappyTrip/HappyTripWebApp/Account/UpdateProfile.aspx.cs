using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HappyTrip.Model.Entities.UserAccount;

namespace HappyTripWebApp
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Membership.GetUser() != null)
                {
                    ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());

                    UpdateLabel.Text = "";
                    DateTime dateOnly = com.Personal.DateOfBirth;
                    
                    Name.Text = com.Personal.FullName;
                    date.Text = dateOnly.ToString("MM/dd/yyyy");
                    Address1.Text = com.Contact.Address;
                    City.Text = com.Contact.City;
                    State.Text = com.Contact.State;
                    Pincode.Text = com.Contact.PinCode;
                    MobileNo.Text = com.Contact.MobileNo;

                    if (com.Personal.Gender == 'M' || com.Personal.Gender == 'm')
                    {
                        lbgender.Text = "Male";
                        Gender.SelectedIndex = 1;
                    }
                    else
                    {
                        lbgender.Text = "Female";
                        Gender.SelectedIndex = 2;
                    }
                    lbname.Text = com.Personal.FullName;
                    lbDOB.Text = dateOnly.ToString("MM/dd/yyyy");
                    lbAddress.Text = com.Contact.Address;
                    lbCity.Text = com.Contact.City;
                    lbState.Text = com.Contact.State;
                    lbPib.Text = com.Contact.PinCode;
                    lbMobile.Text = com.Contact.MobileNo;
                }

            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    ProfileCommon com = ProfileCommon.GetProfile(Membership.GetUser().UserName.ToString());
                    com.Personal.FullName = Name.Text;
                    com.Personal.Gender = Convert.ToChar(Gender.SelectedValue.ToString());
                    com.Personal.DateOfBirth = Convert.ToDateTime(date.Text);
                    com.Contact.Address = Address1.Text;
                    com.Contact.City = City.Text;
                    com.Contact.MobileNo = MobileNo.Text;
                    com.Contact.PinCode = Pincode.Text;
                    com.Contact.State = State.Text;
                    com.Save();
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception)
            {
                lbl_error.Text = "Sorry !!! Unable to Update your Account.Please Try Again";
            }
        }

    }
}