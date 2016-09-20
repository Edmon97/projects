using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderRepository
    {
        IQueryable<Order> All { get; }
        void InsertOrUpdate(Order order);
        void Remove(Order order);
        void Save();
    }
}
