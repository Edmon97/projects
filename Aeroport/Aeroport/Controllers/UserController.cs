using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;

namespace Aeroport.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private static AeroportContext context = new AeroportContext();
        private UnitOfWork uof = new UnitOfWork(context);
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(uof.Users.GetAll());
        }

        public ActionResult Edit(int id)
        {
            Dal.User tempUser = uof.Users.FindById(id);
            if (tempUser != null)
                return View(tempUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            uof.Users.Update(user);
            return RedirectToAction("Index");
        }
    }
}
