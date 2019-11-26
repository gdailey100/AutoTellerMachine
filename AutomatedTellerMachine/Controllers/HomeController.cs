using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDbContext db = new IApplicationDbContext();

        // get /home/index
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            //var checkingAccountId  = db.CheckingAccounts.Where(c => c.AccountNumber == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;
            return View();
        }

        // get /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // get /home/contact
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // send the message to someone
            ViewBag.TheMessage = "Thanks!, we got your message.";

            return PartialView("_ContactThanks");
        }

        public ActionResult Foo()
        {
            return View("about");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return new HttpStatusCodeResult(403);
            return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
        }
    }
}