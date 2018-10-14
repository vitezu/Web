using Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Soccer.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        public ActionResult DetailTeam (int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var team = db.Teams.Include(t=>t.Players).FirstOrDefault(t => t.Id == id);
            return View(team);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            SelectList teams = new SelectList(db.Teams, "Id", "Name");
            ViewBag.Teams = teams;
            return View();
        }
        [HttpPost]
        public ActionResult Create (Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit (int? id) 
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Player player = db.Players.Find(id);
            if(player==null)
            {
                return HttpNotFound();
            }
            SelectList teams = new SelectList(db.Teams, "Id", "Name", player.TeamId);
            ViewBag.Teams = teams;
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit (Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
           
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmedDelete (int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            db.Players.Remove(player);
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