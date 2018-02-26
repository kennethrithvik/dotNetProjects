using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3
{
    class Contact
    {
        public Contact(string mstrFirstName, string mstrLastName, string mstrMobile, string mstrEmail)
        {
            FirstName = mstrFirstName;
            LastName = mstrLastName;
            Mobile = mstrMobile;
            Email = mstrEmail;
        }
        private string mstrFirstName;

        public string FirstName
        {
            get { return mstrFirstName; }
            set
            {
                if (value != null)
                    mstrFirstName = value;
                else
                    throw new Exception("Name should not be null");
            }
        }
        private string mstrLastName;

        public string LastName
        {
            get { return mstrLastName; }
            set
            {
                if (value != null)
                    mstrLastName = value;
                else
                    throw new Exception("Name should not be null");
            }
        }

        private string mstrMobile;
        public string Mobile
        {
            get { return mstrMobile; }
            set
            {
                if (value != null)
                    mstrMobile = value;
                else
                    throw new Exception("Mobile no. should not be null");
            }
        }

        private string mstrEmail;
        public string Email
        {
            get { return mstrEmail; }
            set
            {
                if (value != null)
                    mstrEmail = value;
                else
                    throw new Exception("Email should not be null");
            }
        }



        public virtual string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("First Name: {0}\n", this.FirstName);
            sb.AppendFormat("Last Nmae: {0}\n", this.LastName);
            sb.AppendFormat("Mobile no: {0}\n", this.Mobile);
            sb.AppendFormat("Email: {0}\n", this.Email);
            
            return sb.ToString();

        }
    }
}
