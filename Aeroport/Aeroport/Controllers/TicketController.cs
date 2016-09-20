using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;

namespace Aeroport.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new AeroportContext("DefaultConnection"));
        private List<Flyght> flyghts;
        private List<Ticket> tickets;
        //
        // GET: /Ticket/
        public TicketController()
        {
            flyghts = uow.Flyghts.GetAll().ToList();
            tickets = uow.Tickets.GetAll().ToList();
        }

        public ActionResult Index()
        {
            return View(flyghts); 
        }

        public ActionResult ShowAll(string name)
        {
            if (name != null)
                return View(tickets.Where(u=>(u.User.UserName ==name)).ToList());
            return View(tickets);
        }

        [Authorize]
        public ActionResult BuyTicket(int id)
        {
            Flyght flyght = uow.Flyghts.FindById(id);
            Dal.User user = uow.Users.GetAll().Where(u => u.UserName == User.Identity.Name).SingleOrDefault();
            Ticket ticket = new Ticket() {Flyght = flyght,User = user };
            uow.Tickets.Create(ticket);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteTicket(int id)
        {
            Ticket temp = uow.Tickets.FindById(id);
            uow.Tickets.Delete(temp);
            return PartialView(tickets);
        }

    }
}
