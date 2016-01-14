using Auction.Model.Models;
using Auction.Service;
using AutoMapper;
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
            var users =Mapper.Map<IEnumerable<UserViewModel>>(userService.GetUsers());
            return View(users);
        }

        [HttpGet]
        public ActionResult EditUser(int id = 0)
        {
            var user =Mapper.Map<UserViewModel>(userService.GetUser(id));
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<User>(userViewModel);
                userService.Update(user);
                ViewBag.Result = "Updated";
            }
            else
                ViewBag.Result = "Error";
            return View(userViewModel);
        }

        public ActionResult SearchUser(string search)
        {
           var users = Mapper.Map<IEnumerable<UserViewModel>>(userService.Search(search));            
            return View("Index", users);

        }
    }
}