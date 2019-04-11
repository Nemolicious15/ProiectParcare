using ProiectColectiv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectColectiv.Controllers
{
    public class HomeController : BaseController
    {

        public ProiectColectivEntities db = new ProiectColectivEntities();

        public ActionResult Index()
        {
          //  var x = db.Parcare.FirstOrDefault().LocParcare.FirstOrDefault().Rezervare.FirstOrDefault();
            return View(db.Parcare.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}