using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private SBContext _context;

        public UserRepository(SBContext _context)
        {
            this._context = _context;
        }

        public IQueryable<UserProfile> All
        {
            get { return _context.UserProfiles; }
        }

        public void InsertOrUpdate(UserProfile userProfile)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.UserId == userProfile.UserId).SingleOrDefault();
            if (user != null)
                user.UserName = userProfile.UserName;
            else
                _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();
        }

        public void Remove(UserProfile userProfile)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.UserId == userProfile.UserId).SingleOrDefault();
            if (user != null)
            {
                _context.UserProfiles.Remove(user);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
