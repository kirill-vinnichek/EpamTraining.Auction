using Auction.Model.Models;
using Auction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult EditUser(int id = 0)
        {
            var user = userService.GetUser(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.Update(user);
                ViewBag.Result = "Updated";
            }
            else
                ViewBag.Result = "Error";
            return View(user);
        }

        public ActionResult SearchUser(string search)
        {
           var users =  userService.Search(search);

            return View("Index", users);

        }
    }
}