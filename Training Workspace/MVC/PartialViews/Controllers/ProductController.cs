using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Products prds = new Products();
            return View(prds.GetProducts());
        }
    }
}