using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UnitOfWork:IDisposable
    {
        AeroportContext context;
        bool disposed = false;
        private CityRepository cityRepository;
        private FlyghtRepository flyghtRepository;
        private PlaneRepository planeRepository;
        private TicketRepository ticketRepository;
        private UserRepository userRepository;

        public UnitOfWork(AeroportContext context)
        {
            this.context = context;
        }

        public CityRepository Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(context);
                return cityRepository;
            }
            set { cityRepository = value; }
        }

        public FlyghtRepository Flyghts
        {
            get
            {
                if (flyghtRepository == null)
                    flyghtRepository = new FlyghtRepository(context);
                return flyghtRepository;
            }
            set { flyghtRepository = value; }
        }

        public PlaneRepository Planes
        {
            get
            {
                if (planeRepository == null)
                    planeRepository = new PlaneRepository(context);
                return planeRepository;
            }
            set { planeRepository = value; }
        }

        public TicketRepository Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(context);
                return ticketRepository;
            }
            set { ticketRepository = value; }
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
            set { userRepository = value; }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    this.disposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
