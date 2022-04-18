using Meyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Meyer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult profile()
        {
            ViewBag.Message = "Din profil";

            return View();
        }

        public ActionResult beregn2()
        {
            ViewBag.Messasge = "Dette er vores beregner, hvor du kan beregne sandsynligheden for dit næste kast";
            return View();
        }

        public ActionResult regler()
        {
            ViewBag.Message = "Her kan du læse om reglerne for Meyer, hvis du er i tvivl eller ikke kender dem";
            return View();
        }

        public ActionResult bruger()
        {
            ViewBag.Message = "Dette er siden til brugeren";
            return View();
        }


        [HttpPost]
        public ActionResult FåSandsynlighed(int? slag)
        {


            return Json(db.sandsynlighed.Where(x => x.Kast == slag));

        }

        public ActionResult ProfilOpretLogin()
        {
            return View();
        }
        MeyerEntities db = new MeyerEntities();
    }
}