using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace FiltersExceptionLogging.Logger
{
    public class LogManager
    {
        public static void Log(String Name,RouteData routedata)
        {
            FileStream file = new FileStream(@"D:\Tesco batch5\MVC\FiltersExceptionLogging\Logger\logger.txt", FileMode.Append);
            StreamWriter sw =new StreamWriter(file);
            var controllername = routedata.Values["controller"];
            var actionname = routedata.Values["action"];
            var message = string.Format("{0};    controller:{1};    action:{2};    accessed at:{3}", Name, controllername, actionname, DateTime.Now);

            sw.WriteLine(message);
            sw.WriteLine("---------------------------");
            sw.Close();
            file.Close();
        }

        public static void ExceptionLog(String Name, Exception ex)
        {
            FileStream file = new FileStream(@"D:\Tesco batch5\MVC\FiltersExceptionLogging\Logger\Exceptionlogger.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(file);
            
            var message = string.Format("{0};    ExceptionMessage:{1};    accured at:{2}", Name, ex.Message,DateTime.Now);

            sw.WriteLine(message);
            sw.WriteLine("---------------------------");
            sw.Close();
            file.Close();
        }
        public static void AuthenticationLog(String Name, string data)
        {
            FileStream file = new FileStream(@"D:\Tesco batch5\MVC\FiltersExceptionLogging\Logger\Authenticationlogger.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(file);

            var message = string.Format("{0};    Message:{1};    accured at:{2}", Name, data, DateTime.Now);

            sw.WriteLine(message);
            sw.WriteLine("---------------------------");
            sw.Close();
            file.Close();
        }
        public static void AutherizationLog(String Name, string data)
        {
            FileStream file = new FileStream(@"D:\Tesco batch5\MVC\FiltersExceptionLogging\Logger\Autherizationlogger.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(file);

            var message = string.Format("{0};    Message:{1};    accured at:{2}", Name, data, DateTime.Now);

            sw.WriteLine(message);
            sw.WriteLine("---------------------------");
            sw.Close();
            file.Close();
        }
    }
}