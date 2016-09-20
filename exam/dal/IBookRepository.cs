using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBookRepository
    {
        IQueryable<Book> All { get; }
        void InsertOrUpdate(Book book);
        void Remove(Book book);
        void Save();
    }
}
