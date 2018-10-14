using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStory.Models;
using System.Data.Entity;

namespace WebStory.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            
            return View(db.Books);
        }

        public ActionResult Array ()
        {
            return View();
        }

        [HttpPost]
        public string Array (string[] names)
        {
            string fin = "";
            for(int i = 0; i<names.Length; i++)
            {
                fin += names[i] + "; ";
            }
            return fin;
        }

        public ActionResult Add()
        {
            return View(db.Books.ToList());
        }

        [HttpPost]
        public string Add(List<Book> books)
        {

            return books.Count().ToString();

        }


        public ActionResult Author()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Author(Author author)
        {
            return View();
        }


        public ActionResult BookView(int id)
        {
            Book book = db.Books.Find(id);
            return View(book);
        }

        [HttpGet]
        public ActionResult EditBook (int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
            Book book = db.Books.Find(id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        } 

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (int id)
        {
            Book book = db.Books.Find(id);
            if(book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
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