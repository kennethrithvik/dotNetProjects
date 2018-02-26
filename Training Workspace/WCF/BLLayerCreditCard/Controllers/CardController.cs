using BLLayerCreditCard.CardRepository;
using BLLayerCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BLLayerCreditCard.Controllers
{
    public class CardController : Controller
    {
        ICardRepo crepo;
        //public CardController()
        //{
        //    crepo = new CardRepo();
        //}
        public CardController(ICardRepo cr)
        {
            crepo = cr;
        }
        // GET: Card
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ValCard(string card)
        {
            CreditCard data = new JavaScriptSerializer().Deserialize<CreditCard>(card);
            bool result=crepo.ValidateCard(data.CardNo, data.ExpiryDate);
            
            string json = new JavaScriptSerializer().Serialize(result);
            JsonResult a= Json(json, JsonRequestBehavior.AllowGet);
            return a;
        }
    }
}