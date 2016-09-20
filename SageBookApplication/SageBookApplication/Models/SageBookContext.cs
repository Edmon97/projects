using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SageBookApplication.Models
{
    public class SageBookContext : DbContext
    {
        public SageBookContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SageBook> SageBooks { get; set; }
    }
}