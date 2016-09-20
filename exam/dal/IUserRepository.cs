using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public interface IUserRepository
    {
        IQueryable<UserProfile> All { get; }
        void InsertOrUpdate(UserProfile user);
        void Remove(UserProfile user);
        void Save();
    }
}
