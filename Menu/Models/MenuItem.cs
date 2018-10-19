using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menu.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Header { get; set; } //заголвок
        public string Url { get; set; }
        public int? Order { get; set; } //порядк следования в подменю
        public int? ParentId { get; set; }// ссылка на родит меню

        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; }

        public MenuItem()
        {
            Children = new List<MenuItem>() { };
        }




    }
}