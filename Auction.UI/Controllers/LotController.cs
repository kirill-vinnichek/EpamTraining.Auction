using Auction.Model.Models;
using Auction.Service;
using Auction.UI.Helpers;
using Auction.UI.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace Auction.UI.Controllers
{
    public class LotController : Controller
    {

        private ILotService lotService;
        private IUserService userService;
        public LotController(ILotService lotService, IUserService userService)
        {
            this.lotService = lotService;
            this.userService = userService;
        }



        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            if (TempData.ContainsKey("imgCount"))
                TempData.Remove("imgCount");
            TempData.Add("imgCount", 0);
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddLotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lot = Mapper.Map<Lot>(model);
                lot.Images = new List<Image>();
                if (model.Urls != null)
                {
                    foreach (var u in model.Urls)
                    {
                        lot.Images.Add(new Image()
                        {
                            Url = u
                        });
                    }
                }
                TempData.Remove("imgCount");
                var user = userService.GetUserByEmail(User.Identity.Name);
                lot.Seller = user;
                user.Lots.Add(lot);
                lotService.AddLot(lot);
                return RedirectToAction("Details", new { id = lot.LotId });
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult MakeBet(int id = 0)
        {
            var lot = lotService.GetLot(id);
            if (lot == null)
                return HttpNotFound();
            var user = userService.GetUserByEmail(User.Identity.Name);

            if (Request.IsAjaxRequest())
            {
                if (lotService.MakeBet(user, lot))
                    return PartialView("_BetPartial", lot.Bets.Last());
                return Json(new { success = false },JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (lotService.MakeBet(user, lot))
                    return RedirectToAction("Details", new { id = lot.LotId });
                else
                    return RedirectToAction("Details", new { id = lot.LotId });
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {

            var lot = lotService.GetLot(id);
            if (lot == null)
                return HttpNotFound();
            if (lot.Seller.Email == User.Identity.Name || User.IsInRole("admin"))
                return View(lot);
            else
                return new HttpUnauthorizedResult();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Lot lot)
        {
            if (lot.Seller.Email == User.Identity.Name || User.IsInRole("admin"))
            {
                lotService.Update(lot);
                return View(lot);
            }
            else
                return new HttpUnauthorizedResult();
        }


        public ActionResult Details(int id = 0)
        {

            var lot = lotService.GetLot(id);
            if (lot == null)
                return HttpNotFound();
            var model = Mapper.Map<LotDetailsViewModel>(lot);

            return View(model);
        }


        public ActionResult Upload(HttpPostedFileBase img)
        {
            if (img != null && Utils.IsSupportedMimeType(img.ContentType))
            {
                int count = (int)TempData["imgCount"];
                if (count < 3)
                {
                    TempData["imgCount"] = ++count;
                    var ext = Path.GetExtension(img.FileName);
                    var path = Path.Combine(ConfigurationManager.AppSettings["ImagesPath"], Guid.NewGuid().ToString() + ext);
                    var mappedPath = Server.MapPath(path);
                    if (System.IO.File.Exists(mappedPath))
                        System.IO.File.Delete(mappedPath);
                    img.SaveAs(mappedPath);
                    var priviewPath = mappedPath = Url.Content(path);

                    return Json(new { success = true, img = path, preview_path = priviewPath });
                }

            }

            return Json(new { success = false, result = "error" });
        }

    }
}