using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using BookStore.Models;

namespace BookStory.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
       

    }

}