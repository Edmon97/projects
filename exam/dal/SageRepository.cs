using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SageRepository : ISageRepository
    {
        private SBContext _context;

        public SageRepository(SBContext _context)
        {
            this._context = _context;
        }

        public IQueryable<Sage> All
        {
            get { return _context.Sages; }
        }

        public void InsertOrUpdate(Sage sg)
        {
            Sage sage = _context.Sages.Where(s => s.Id == sg.Id).SingleOrDefault();
            if (sage != null)
            {
                sage.Age = sg.Age;
                sage.Name = sg.Name;
            }
            else
                _context.Sages.Add(sg);
            _context.SaveChanges();
        }

        public void Remove(Sage sg)
        {
            Sage sage = _context.Sages.Where(s => s.Id == sg.Id).SingleOrDefault();
            if (sage != null)
            {
                _context.Sages.Remove(sage);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
