using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperORM.Models
{
    public class Movies
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int total { get; set; }
        public string desciption { get; set; }

    }
}