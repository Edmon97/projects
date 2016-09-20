using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dal
{
    public class AeroportContext:DbContext
    {
        public AeroportContext(string connectionName = "DefaultConnection")
            : base(connectionName)
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flyght> Flyghts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
