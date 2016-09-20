using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    public class PlaneRepository : BaseRepository<Plane>
    {
        public PlaneRepository(AeroportContext context)
            : base(context)
        {

        }
    }
}
