using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Menu.Models;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        MenuContext db = new MenuContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu ()
        {
            List<MenuItem> menuItems = db.MenuItems.ToList();
            return PartialView(menuItems);
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