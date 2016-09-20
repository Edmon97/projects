using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SageBookApplication.Models;

namespace SageBookApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*SageBookContext sageBookContext = new SageBookContext();
            for (int i = 1; i <= 10; i++)
            {
                sageBookContext.Books.Add(new Book() { Name = "Book#"+i, Count = 100*i, Image = "http://www.magic4walls.com/wp-content/uploads/2013/11/abstraction-ss-2.jpg" });
            }
            sageBookContext.SaveChanges();*/
            return View();
        }

        public ActionResult ShowBooks()
        {
            return View();
        }

        public ActionResult ShowSages()
        {
            return View();
        }
    }
}
