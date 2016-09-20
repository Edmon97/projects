using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;

namespace Aeroport.Controllers
{
    public class FlyghtController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));
        //
        // GET: /Flyght/

        public ActionResult Index()
        {
            List<Flyght> flyghts = uow.Flyghts.GetAll().ToList();
            return View(flyghts);
        }

        public ActionResult Create()
        {
            return View(new Flyght());
        }

        [HttpPost]
        public ActionResult Create(Flyght flyght)
        {
            City cityFrom = uow.Cities.FindById(flyght.CityFrom.Id);
            City cityTo = uow.Cities.FindById(flyght.CityTo.Id);
            Plane plane = uow.Planes.FindById(flyght.Plane.Id);
            uow.Flyghts.Create(new Flyght() { CityTo = cityTo, CityFrom = cityFrom, Plane = plane,Date = flyght.Date});
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Flyght temp = uow.Flyghts.FindById(id);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(Flyght flyght)
        {
            flyght.CityFrom = uow.Cities.FindById(flyght.CityFrom.Id);
            flyght.CityTo= uow.Cities.FindById(flyght.CityTo.Id);
            flyght.Plane = uow.Planes.FindById(flyght.Plane.Id);
            uow.Flyghts.Update(flyght);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Flyght temp = uow.Flyghts.FindById(id);
            if (temp != null)
                uow.Flyghts.Delete(temp);
            return PartialView(uow.Flyghts.GetAll().ToList());
        }

    }
}
