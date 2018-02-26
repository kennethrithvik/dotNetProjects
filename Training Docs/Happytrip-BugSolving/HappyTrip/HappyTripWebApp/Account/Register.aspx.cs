using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HappyTrip.Model.Entities.UserAccount;
using System.Web.Security;


namespace HappyTripWebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl);
            }

            aspButtonLink.RegisterAsyncPostBackControl(hlCheckAvailaibilty);
        }

        protected void bt_Submit_Click(object sender, EventArgs e)
        {
            string UserName = last_name.Text.Trim();
            string Email = EMailId.Text.Trim();
            string Password = password.Text.Trim();
            char gender = char.Parse(dl_gender.SelectedValue);
            DateTime DOB = DateTime.Parse(date.Value.ToString());
            try
            {
                MembershipUser user = Membership.CreateUser(Email, Password);
                Roles.AddUserToRole(user.UserName, "traveluser");
                ProfileCommon com = ProfileCommon.GetProfile(Email);
                com.Personal.FullName = UserName;
                com.Personal.Gender = gender;
                com.Save();
                Response.Redirect("Register_Success.aspx", false);
            }
            catch (MembershipCreateUserException ex)
            {
                if (ex.StatusCode == MembershipCreateStatus.InvalidPassword)
                {
                    lb_password_error.Visible = true;
                    lb_password_error.Text = "Invalid password";
                }
                else if (ex.StatusCode == MembershipCreateStatus.InvalidEmail)
                {
                    email_error.Visible = true;
                    email_error.Text = "Invalid e-mail";
                }
                else if (ex.StatusCode == MembershipCreateStatus.InvalidUserName)
                {
                    lb_error_username.Visible = true;
                    lb_error_username.Text = "Invalid user name";
                }
                else if (ex.StatusCode == MembershipCreateStatus.DuplicateEmail)
                {
                    email_error.Visible = true;
                    email_error.Text = "E-mail id already present";
                }
                else if (ex.StatusCode == MembershipCreateStatus.DuplicateUserName)
                {
                    lb_error_username.Visible = true;
                    lb_error_username.Text = "Login Id  already present";
                }

                else
                {
                    gendral_error.Visible = true;
                    gendral_error.Text = "Sorry !!! Unable to register. Please try again";
                }


            }
            catch (Exception)
            {
                gendral_error.Visible = true;
                gendral_error.Text = "Sorry !!! Unable to register. Please try again";
            }
        }

        protected void hlCheckAvailaibilty_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser member = Membership.GetUser(EMailId.Text.Trim());
                if (member != null)
                {
                    email_error.Visible = true;
                    email_error.Text = "User name already exists";
                    EMailId.Text = string.Empty;
                }
                else if (EMailId.Text == string.Empty)
                {
                    email_error.Visible = true;
                    email_error.Text = "E-mail Id not entered";
                }
                else
                {
                    email_error.Visible = true;
                    email_error.Text = "E-mail Id available";
                    email_error.Attributes.Add("ForeColor", "Green");
                }
            }         
            catch (Exception)
            {
                gendral_error.Visible = true;
                gendral_error.Text = "Sorry !!! Unable to register. Please try again";
            }
                
        }


    }
}