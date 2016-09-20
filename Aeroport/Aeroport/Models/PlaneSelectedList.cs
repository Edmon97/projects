using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace Aeroport.Models
{
    public class PlaneSelectedList
    {
         private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));

        public List<System.Web.Mvc.SelectListItem> Planes { get; set; }

        public PlaneSelectedList()
        {
            Planes = new List<System.Web.Mvc.SelectListItem>();
            uow.Planes.GetAll().ToList().ForEach(plane => 
            {
                System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem() { Text= plane.Model,Value=plane.Id.ToString()};
                Planes.Add(item);
            });
        }
    }
}