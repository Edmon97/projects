using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    [Table("Tickets")]
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Flyght Flyght { get; set; }
    }
}
