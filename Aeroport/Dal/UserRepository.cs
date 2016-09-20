using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AeroportContext context)
            : base(context)
        {

        }
    }
}
