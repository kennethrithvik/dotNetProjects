using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TOB
{
    class AccountPriveledgeManager
    {
        static AccountPriveledgeManager()
        {
            var apps = ConfigurationManager.AppSettings;
            foreach (var item in apps.AllKeys)
            {
                double val = double.Parse(apps[item]);
                PrivilageType typ = (PrivilageType) Enum.Parse(typeof (PrivilageType), item);
                dailymap.Add(typ,val);
            }
            //foreach (var item in dailymap)
            //{
            //    Console.WriteLine(item.Key + "  " + item.Value.ToString());

            //}


        }

        private static Dictionary<PrivilageType, double> dailymap = new Dictionary<PrivilageType, double>();

        public double getDailyLimit(PrivilageType type)
        {
            return dailymap[type];
        }

    }
}
