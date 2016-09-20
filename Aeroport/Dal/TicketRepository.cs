using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Dal
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        public TicketRepository(AeroportContext context)
            : base(context)
        {

        }

        public List<Ticket> GetTicketsByUserName(string name)
        {
            List<Ticket> tickets = GetAll().Where(u => u.User.UserName == name).ToList();
            return tickets;
        }
    }
}
