using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using System.Web.Security;

namespace Aeroport.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));

        public ActionResult Index()
        {
            List<Flyght> flyghts = uow.Flyghts.GetAll().ToList();
            return View(flyghts);
        }

        [Authorize(Roles="Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cabinet()
        {
            return View(uow.Tickets.GetAll().ToList().Where(u => (u.User.UserName == User.Identity.Name)).ToList());
        }
    }
}
