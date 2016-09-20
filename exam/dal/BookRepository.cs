using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookRepository : IBookRepository
    {
        private SBContext _context;

        public BookRepository(SBContext _context)
        {
            this._context = _context;
        }

        public IQueryable<Book> All
        {
            get { return _context.Books; }
        }

        public void InsertOrUpdate(Book bk)
        {
            Book book = _context.Books.Where(s => s.Id == bk.Id).SingleOrDefault();
            if (book != null)
            {
                book.Name = bk.Name;
                book.Pages = bk.Pages;
            }
            else
                _context.Books.Add(bk);
            _context.SaveChanges();
        }

        public void Remove(Book bk)
        {
            Book book = _context.Books.Where(s => s.Id == bk.Id).SingleOrDefault();
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
