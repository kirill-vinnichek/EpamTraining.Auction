using Auction.Model.Models;
using Auction.Service;
using Auction.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.UI.Controllers
{
    //TODO: Добавить страничку ошибки
    public class HomeController : Controller
    {
        private readonly int pageSize = 10;
        private ILotService lotService;

        public HomeController(ILotService lotService)
        {
            this.lotService = lotService;
        }

        // GET: Home
        public ActionResult Index(int? page)
        {

            int pageNumber = (page ?? 1);
            int pageCount = lotService.Count() / pageSize;
            var lots = lotService.GetSomeLots(pageSize, (pageNumber - 1) * pageSize);           
            var viewModel = new IndexViewModel()
            {
                PageCount = pageCount,
                Page = pageNumber,
                Lots = lots,
                Categories = new List<Category>()
            };
            return View(viewModel);
        }

        
        public ActionResult Search (string search,int? page)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                
                int pageNumber = (page ?? 1);
                int pageCount = lotService.Count() / pageSize;
                //TODO: выделить метод
                var lots = lotService.GetSomeLots(pageSize, (pageNumber - 1) * pageSize,search);                
                var viewModel = new IndexViewModel()
                {
                    PageCount = pageCount,
                    Page = pageNumber,
                    Lots = lots,
                    Categories = new List<Category>()
                };
                return View("Index", viewModel);
            }
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            return View();
        }

 


    }
}