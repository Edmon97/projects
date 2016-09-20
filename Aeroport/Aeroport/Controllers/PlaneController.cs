using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;

namespace Aeroport.Controllers
{
    [Authorize(Roles="Admin")]
    public class PlaneController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));
        //
        // GET: /Plane/

        public ActionResult Index()
        {
            List<Plane> planes = uow.Planes.GetAll().ToList();
            return View(planes);
        }

        public ActionResult Create()
        {
            return View(new Plane());
        }

        [HttpPost]
        public ActionResult Create(Plane plane)
        {
            uow.Planes.Create(plane);
            return RedirectToAction("Index");
        }

        public ActionResult Save(Plane plane)
        {
            uow.Planes.Update(plane);
            List<Plane> planes = uow.Planes.GetAll().ToList();
            return PartialView(planes);
        }

        public ActionResult Delete(int id)
        {
            Plane temp = uow.Planes.FindById(id);
            if (temp != null)
                uow.Planes.Delete(temp);
            List<Plane> planes = uow.Planes.GetAll().ToList();
            return PartialView("Save", planes);
        }

    }
}
