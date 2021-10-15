using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NJTransitProject.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        private NJData1 data1 = new NJData1();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult TimeTable()
        {

            return View(data1.TrainTimeTables.ToList());
        }
    }
}