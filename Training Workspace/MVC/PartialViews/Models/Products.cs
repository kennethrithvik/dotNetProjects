using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViews.Models
{
    public class Products
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product{ID=1,Name="Mobile",Price=599,Description="Call People",ImagePath=@"images\adds\add2.jpg"},
                new Product{ID=2,Name="TV",Price=699,Description="Watch Movies and shows",ImagePath=@"images\adds\add3.jpg"},
                new Product{ID=3,Name="Battery",Price=799,Description="Mini power source",ImagePath=@"images\adds\add4.jpg"},
                new Product{ID=4,Name="Tablet",Price=499,Description="small computer",ImagePath=@"images\adds\add1.jpg"},
                new Product{ID=5,Name="Computer",Price=999,Description="normal computer",ImagePath=@"images\adds\add5.jpg"},
                new Product{ID=6,Name="Radio",Price=899,Description="Listen to music",ImagePath=@"images\adds\add2.jpg"},
                new Product{ID=7,Name="Washer",Price=1000,Description="Wash clothes",ImagePath=@"images\adds\add3.jpg"},
                new Product{ID=8,Name="Mixie",Price=432,Description="Gring things",ImagePath=@"images\adds\add5.jpg"}
            };
        }
    }
}