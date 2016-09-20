using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace Aeroport.Models
{
    public class CitySelectedList
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));

        public List<System.Web.Mvc.SelectListItem> Cities { get; set; }

        public CitySelectedList()
        {
            Cities = new List<System.Web.Mvc.SelectListItem>();
            uow.Cities.GetAll().ToList().ForEach(city => 
            {
                System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem() { Text= city.Name,Value=city.Id.ToString()};
                Cities.Add(item);
            });
        }
    }
}