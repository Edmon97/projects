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
    [Table("Users")]
    public class User:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
