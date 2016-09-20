using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dal.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Project Project { get; set; }
        public int Count { get; set; }
    }
}