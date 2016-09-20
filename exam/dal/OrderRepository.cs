using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepository:IOrderRepository
    {
        private SBContext _context;

        public OrderRepository(SBContext _context)
        {
            this._context = _context;
            this._context.Database.Initialize(true);
        }

        public IQueryable<Order> All
        {
            get { return _context.Orders; }
        }

        public void InsertOrUpdate(Order or)
        {
            Order order = _context.Orders.Where(s => s.Id == or.Id).SingleOrDefault();
            if (order != null)
            {
                order.User = or.User;
                order.Book = or.Book;
            }
            else
                _context.Orders.Add(or);
            _context.SaveChanges();
        }

        public void Remove(Order or)
        {
            Order order = _context.Orders.Where(s => s.Id == or.Id).SingleOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
