using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    public class FlyghtRepository : BaseRepository<Flyght>
    {
        public FlyghtRepository(AeroportContext context)
            : base(context)
        {

        }
    }
}
