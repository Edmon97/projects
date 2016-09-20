using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SageBookApplication.Models;

namespace SageBookApplication.Controllers
{
    public class BookController : ApiController
    {
        SageBookContext _sageBookContext = new SageBookContext();

        [Queryable]
        public IQueryable<Book> GetBooks()
        {
            return _sageBookContext.Books;
        }

        public Book GetBook(int id)
        {
            Book book = _sageBookContext.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            _sageBookContext.Books.Add(book);
            _sageBookContext.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                _sageBookContext.Entry(book).State = EntityState.Modified;
                _sageBookContext.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = _sageBookContext.Books.Find(id);
            if(book!=null)
            {
                _sageBookContext.Books.Remove(book);
                _sageBookContext.SaveChanges();
            }
        }
    }
}
