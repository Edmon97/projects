using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace exam.Controllers
{
    public class HomeController : Controller
    {
        private ISageRepository _sageRepository;
        private IBookRepository _bookRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;

        public HomeController(ISageRepository _sR, IBookRepository _bR,IOrderRepository _oR, IUserRepository _uR)
        {
            this._sageRepository = _sR;
            this._orderRepository = _oR;
            this._bookRepository = _bR;
            this._userRepository = _uR;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        [Authorize]
        public ActionResult BuyBook( int id = 0)
        {
            if (id != 0)
            {
                Book book = _bookRepository.All.Where(b => b.Id == id).SingleOrDefault();
                UserProfile userProfile =
                    _userRepository.All.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                Order order = new Order(){User = userProfile.UserId, Book = book.Id};
                _orderRepository.InsertOrUpdate(order);
            }
            return PartialView(_bookRepository.All);
        }

        #region AuthorizeMethods

        [Authorize] 
        public ActionResult Cabinet()
        {
            int id = _userRepository.All.Where(u => u.UserName == User.Identity.Name).Select(us => us.UserId).SingleOrDefault();
            return View(id);
        }

        [Authorize(Roles = "Admin")] // К данному методу действия могут получать доступ только пользователи с ролью Admin
        public ActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult BooksPanel()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SagesPanel()
        {
            return View();
        }

        #endregion

        #region Admin Methods

        public ActionResult ShowOrders(int id = 0)
        {
            IQueryable<Order> orders;
            if (id == 0)
                orders = _orderRepository.All;
            else
                orders = _orderRepository.All.Where(u => u.User == id);
            return PartialView(orders);
        }

        #endregion

        #region Sages

        public ActionResult AddSage(Sage sage)
        {
            if (sage.Name != null)
            {
                _sageRepository.InsertOrUpdate(sage);
                return PartialView("ShowSages", _sageRepository.All);
            }
            return PartialView();
        }

        public ActionResult ShowSages()
        {
            return PartialView(_sageRepository.All);
        }

        #endregion

        #region Books

        public ActionResult AddBook(Book book)
        {
            if (book.Name != null)
            {
                _bookRepository.InsertOrUpdate(book);
                return PartialView("ShowBooks", _bookRepository.All);
            }
            return PartialView();
        }

        public ActionResult ShowBooks()
        {
            return PartialView(_bookRepository.All);
        }

        #endregion

    }
}
