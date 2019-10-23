using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spark2Auto.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsperPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsperPage);

        public string UrlParam { get; set; }
    }
}
