using QRcodeGenerate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRcodeGenerate.Controllers
{
    public class HomeController : Controller
    {
        TasksContext db = new TasksContext();
        public ActionResult Index()
        {
            return View(db.Technologys);
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