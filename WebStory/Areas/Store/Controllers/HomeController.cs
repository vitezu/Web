using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStory.Areas.Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Store/Home
        public ActionResult Index()
        {
            return View();
        }

        public string Display()
        {
            return "DisplayText";
        }

        [Route ("{id:int}/{name}")]
        public string Test(int id, string name)
        {
            return id.ToString() + name;
        }
    }
}