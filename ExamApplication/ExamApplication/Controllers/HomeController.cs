using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal.Models;
using ExamApplication.Models;

namespace ExamApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ShowProviders()
        {
            return View();
        }

        public ActionResult ShowDetails()
        {
            return View();
        }

        public ActionResult ShowProjects()
        {
            return View();
        }

        public ActionResult ShowOrders()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.Orders);
        }

        public ActionResult CreateOrder()
        {
            return View(new Order());
        }

        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            int ProviderId = order.Provider.Id;
            order.Provider = db.Providers.Where(pr => pr.Id == ProviderId).SingleOrDefault();

            int ProjectId = order.Project.Id;
            order.Project = db.Projects.Where(pr => pr.Id == ProjectId).SingleOrDefault();

            int DetailId = order.Detail.Id;
            order.Detail = db.Details.Where(dt => dt.Id == DetailId).SingleOrDefault();

            db.Orders.Add(order);
            db.SaveChanges();

            return RedirectToAction("ShowOrders");
        }

    }
}
