using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPSnippets.SmsAPI;

namespace SMS
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void SendSms()
        {
            
            SMS.APIType = SMSGateway.Site2SMS;
            SMS.MashapeKey = "<Mashape API Key>";
            SMS.Username = "9060962063";
            SMS.Password = "carpoolingfortesco";
            if ("9060962063".Trim().IndexOf(",") == -1)
            {
                //Single SMS
                SendSms("9060962063".Trim(), "9060962063".Trim());
            }
            else
            {
                //Multiple SMS
                List<string> numbers = "9060962063".Trim().Split(',').ToList();
                SMS.SendSms(numbers, "9060962063".Trim());
            }
        }
    }
}
