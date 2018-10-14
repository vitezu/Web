using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class TestController : Controller
    {
        StudentsContext db = new StudentsContext();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Array ()
        {
            return View();
        }

        [HttpPost]
        public string Array (List<string> names)
        {
            string fin = "";
            for (int i =0; i<names.Count; i++)
            {
                fin += names[i] + "; ";
            }
            return fin;
        }

        public ActionResult Add ()
        {
            return View(db.Books.ToList());
        }

        [HttpPost]
        public ActionResult Add(List<Book> books)
        {

            return View(books);
        }
    }
}