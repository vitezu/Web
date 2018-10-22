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
        [StringLength(30,MinimumLength =2,ErrorMessage ="Длина имени от 2 до 30")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        [Remote("CheckName", "Books", ErrorMessage ="Not valid name")]
        public string Author { get; set; }

        [Required]
        [Range (1800,2050, ErrorMessage ="Недопустимый Год (от 1800 до 2050)")]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Некорректный адрес почты")]
        [Display(Name = "Почта")]
        public string Email { get; set; }


    }
}