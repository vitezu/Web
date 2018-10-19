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

        public ActionResult Index(int? team, string position, int? age)
        {
            IQueryable<Player> players = db.Players.Include(p => p.Team);
            if (team != null && team != 0)
            {
                players = players.Where(p => p.TeamId == team);
            }
           
            if   (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
            {
                players = players.Where(p => p.Position == position);
            }
            if(age !=null && age != 0) 
            {
                players = players.Where(p => p.Age == age);
            }

            List<Team> teams = db.Teams.ToList();
            teams.Insert(0, new Team { Name = "Все", Id = 0 });

            PlayersListViewModel plvm = new PlayersListViewModel
            {
                Players = players.ToList(),
                Teams = new SelectList(teams, "Id", "Name"),
                Position = new SelectList(new List<string>
                {
                    "Все",
                    "Нападающий",
                    "Защитник",
                    "Вратарь"
                }
                ),
                Age = new SelectList(new List<int>
                {
                   0,20,21,22,23,24,25,26,27,28,29,30
                })
            };


            return View(plvm);
          
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