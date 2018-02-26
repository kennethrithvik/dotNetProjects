using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class MVCDemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVCDemoContext() : base("name=MVCDemoContext")
        {
        }

        public System.Data.Entity.DbSet<MVCDemo.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MVCDemo.Models.CabData> CabDatas { get; set; }

        public System.Data.Entity.DbSet<MVCDemo.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<MVCDemo.Models.Cab_Cust> Cab_Cust { get; set; }

        

        
    
    }
}
