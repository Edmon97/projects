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
    [Table("Flyghts")]
    public class Flyght : IEntity
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public virtual City CityFrom { get; set; }
        public virtual City CityTo { get; set; }
        public virtual Plane Plane { get; set; }
    }
}
