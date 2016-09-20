using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;

namespace Aeroport.Controllers
{
    public class CityController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));
        //
        // GET: /City/

        public ActionResult Index()
        {
            return View(uow.Cities.GetAll());
        }

        public ActionResult Create()
        {
            return View(new City());
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            uow.Cities.Create(city);
            return RedirectToAction("Index");
        }

        public ActionResult Save(City city)
        {
            uow.Cities.Update(city);
            return PartialView(uow.Cities.GetAll());
        }

        public ActionResult Delete(int id)
        {
            City temp = uow.Cities.FindById(id);
            if (temp != null)
                uow.Cities.Delete(temp);
            return PartialView("Save", uow.Cities.GetAll());
        }

    }
}
