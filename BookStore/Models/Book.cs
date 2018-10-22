using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}