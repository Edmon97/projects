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
    [Table("Planes")]
    public class Plane : IEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Places { get; set; }
        public string Image { get; set; }
    }
}
