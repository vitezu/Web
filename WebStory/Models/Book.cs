
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebStory.Models
{
    public class Book
    {
        //[HiddenInput (DisplayValue =false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [UIHint("MultilineText")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}