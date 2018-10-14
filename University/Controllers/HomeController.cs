using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using System.Data.Entity;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        StudentsContext db = new StudentsContext();

        public ActionResult Index()
        {
            
            return View(db.Students.ToList());
        }

        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student student = db.Students.Find(id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit (int id = 0)
        {
           
            Student student = db.Students.Find(id);
            if(student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = db.Courses.ToList();
            return View(student);

        }

        [HttpPost]
        public ActionResult Edit (Student student,  int[] selectedCourses)
        {
            Student newStudent = db.Students.Find(student.Id);
            newStudent.Name = student.Name;
            newStudent.Courses.Clear();
            if(selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    newStudent.Courses.Add(c);
                }

            }
            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create ()
        {
            ViewBag.Courses = db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create (Student student, int[] selectedCourses)
        {

            if (selectedCourses != null)
            {
                foreach (var c in db.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    student.Courses.Add(c);
                }
            }

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
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