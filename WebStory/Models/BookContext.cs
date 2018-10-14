using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;

namespace WebStory.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        //public DbSet<Author> Authors { get; set; }
    }

}