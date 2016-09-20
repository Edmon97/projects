using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SageBookApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}