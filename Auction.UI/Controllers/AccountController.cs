using Auction.Service;
using Auction.UI.Providers;
using Auction.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auction.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {         
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {                
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                    
                //Проверяет учетные данные пользователя и управляет параметрами пользователей
                {
                    var user = userService.GetUserByEmail(viewModel.Email);
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var anyUser = userService.GetUserByEmail(viewModel.Email);

                if (anyUser!=null)
                {
                    ModelState.AddModelError("", "This e-mail address is already used");
                    return View(viewModel);
                }

                var membershipUser = ((AuctionMembershipProvider)Membership.Provider)
                    .CreateUser(viewModel);
                if (membershipUser != null)
                {
                    var user = userService.GetUserByEmail(viewModel.Email);
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration error");
                }
            }
            return View(viewModel);
        }



        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}