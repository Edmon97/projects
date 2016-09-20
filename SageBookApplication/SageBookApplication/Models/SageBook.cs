using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SageBookApplication.Models
{
    public class SageBook
    {
        public int Id { get; set; }
        public virtual Sage Sage { get; set; }
        public virtual Book Book { get; set; }
    }
}