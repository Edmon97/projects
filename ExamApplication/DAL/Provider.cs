﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dal.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
    }
}