﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStory.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } //номер  текущей страницы
        public int PageSize { get; set; } //кол объектов на странице
        public int TotalItems { get; set; } //всего объектов
        public int TotalPages
        {             //всего страниц
            get
            {
                return (Int32)Math.Ceiling((Decimal)TotalItems / PageSize);
            }
        }
    }

    public class IndexViewModel {

        public PageInfo PageInfo { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
        

}
