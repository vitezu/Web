using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Controllers
{
    public class BookController : Controller
    {
        public JsonResult CheckName(string name)
        {
            var result = !(name == "Пушкин");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Book
        public string Index(int id)
        {
            return id.ToString();
        }
    }
}