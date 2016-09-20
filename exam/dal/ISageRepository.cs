using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISageRepository
    {
            IQueryable<Sage> All { get; }
            void InsertOrUpdate(Sage sage);
            void Remove(Sage sage);
            void Save();
    }
}
