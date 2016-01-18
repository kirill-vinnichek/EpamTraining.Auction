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
        private IImageService imageService;
        public LotController(ILotService lotService, IUserService userService,IImageService imageService)
        {
            this.lotService = lotService;
            this.userService = userService;
            this.imageService = imageService;
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

            bool isBetMade = lotService.MakeBet(user.UserId, lot.LotId);
                if (Request.IsAjaxRequest())
            {
                if (isBetMade)
                {
                    var betViewModel = Mapper.Map<BetViewModel>(lot.Bets.Last());
                   
                    return PartialView("_BetPartial", betViewModel);
                }
                return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (isBetMade)
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LotViewModel lotViewModel)
        {
            if (ModelState.IsValid)
            {
                if (lotViewModel.Seller.Email == User.Identity.Name || User.IsInRole("admin"))
                {
                    var lot = Mapper.Map<Lot>(lotViewModel);
                    lotService.Update(lot);
                    return View(lotViewModel);
                }
                else
                    return new HttpUnauthorizedResult();
            }
            return View(lotViewModel);
        }


        public ActionResult Details(int id = 0)
        {

            var lot = lotService.GetLot(id);
            if (lot == null)
                return HttpNotFound();
            var model = Mapper.Map<LotDetailsViewModel>(lot);
            if (TempData.ContainsKey("imgCount"))
                TempData.Remove("imgCount");
            TempData.Add("imgCount", model.Images.Count());
            return View(model);
        }


        public ActionResult Upload(HttpPostedFileBase img)
        {
            if (img != null && Utils.IsSupportedMimeType(img.ContentType))
            {                            
                int count = (int)TempData["imgCount"];
                if (count < 3)                {
                    TempData["imgCount"] = ++count;
                    var path = Guid.NewGuid().ToString();
                    imageService.StoreImage(path, img.InputStream);
                    var priviewPath = imageService.GetResizedUrl(path, 200, 200);
                        return Json(new { success = true, img = path, preview_path = priviewPath });
                }

            }

            return Json(new { success = false, result = "error" });
        }

    }
}