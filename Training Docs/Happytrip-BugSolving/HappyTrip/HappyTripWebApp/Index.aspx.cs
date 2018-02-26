using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using HappyTrip.Model.BusinessLayer.Search;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTripWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the travel class to the drop down
             Array itemValues = System.Enum.GetValues(typeof(TravelClass));
            Array itemNames = System.Enum.GetNames(typeof(TravelClass));

            for (int i = 0; i <= itemNames.Length - 1; i++)
            {
                ListItem item = new ListItem(itemNames.GetValue(i).ToString(), itemValues.GetValue(i).ToString());
                ddlClass.Items.Add(item);
            }

           
            //remove previous sessions
            Session.RemoveAll();
        }

        /// <summary>
        /// method to get cities based on the input search term
        /// </summary>
        /// <param name="searchterm"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetCities(string searchterm)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            ISearchManager searchmanager = SearchManagerFactory.GetInstance().Create();

            return jss.Serialize(searchmanager.GetCities().Where(e => e.Name.ToLower().Contains(searchterm)));
        }

        /// <summary>
        /// Event called when the search for flights button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         protected void button_flight_search_Click(object sender, EventArgs e)
        {
            //Get all the information from the controls and send to the server
            
                string departdate = dpt_date.Text;
                string returndate = rtn_date.Text;
                string fromCityName = origin_autocomplete.Text;
                string toCityName = destination_autocomplete.Text;

                if (departdate == "")
                    departdate = "1/1/1900";
                string querystringdate = "&depart_date=" + departdate;

                int td = (int)TravelDirection.OneWay;// travel direction
                if (!one_way.Checked)
                {
                    if (returndate == "")
                        returndate = "1/1/1900";

                    querystringdate = querystringdate + "&return_date=" + returndate;
                    td = (int)TravelDirection.Return;
                }

               Response.Redirect("~/results.aspx?fromCityName=" + fromCityName + "&toCityName=" + toCityName + "&fromid=" + hdnFrom.Value + "&toid=" + hdnTo.Value + "&class=" + ddlClass.SelectedValue + "&td=" + td + querystringdate + "&adults=" + adults.Value);
               
            
        }
    }
}