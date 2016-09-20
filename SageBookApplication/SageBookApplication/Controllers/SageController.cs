using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SageBookApplication.Models;

namespace SageBookApplication.Controllers
{
    public class SageController : ApiController
    {
        SageBookContext _sageBookContext = new SageBookContext();

        [Queryable]
        public IQueryable<Sage> GetSages()
        {
            return _sageBookContext.Sages;
        }

        public Sage GetSage(int id)
        {
            Sage sage = _sageBookContext.Sages.Find(id);
            return sage;
        }

        [HttpPost]
        public void CreateSage([FromBody]Sage sage)
        {
            _sageBookContext.Sages.Add(sage);
            _sageBookContext.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Sage sage)
        {
            if (id == sage.Id)
            {
                _sageBookContext.Entry(sage).State = EntityState.Modified;
                _sageBookContext.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Sage sage = _sageBookContext.Sages.Find(id);
            if (sage != null)
            {
                _sageBookContext.Sages.Remove(sage);
                _sageBookContext.SaveChanges();
            }
        }
    }
}
