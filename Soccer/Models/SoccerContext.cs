using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soccer.Models
{
    public class SoccerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }

    public class PlayersListViewModel
    {
        public ICollection<Player> Players { get; set; }
        public SelectList Teams { get; set; }
        public SelectList Position { get; set; }
        public SelectList Age { get; set; }


    }
}