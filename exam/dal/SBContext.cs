using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace DAL
{
    public class SBContext : DbContext
    {
        public SBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Sage> Sages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}