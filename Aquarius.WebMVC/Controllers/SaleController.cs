using Aquarius.Models.Sale;
using Aquarius.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aquarius.WebMVC.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        // GET: Sale View
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSaleService();

            if (service.CreateSale(model))
            {
                TempData["SaveResult"] = "The Sale was successfully completed.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Sale could not be completed, please try again.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSaleService();
            var model = svc.GetSaleById(id);

            return View(model);
        }

        private SaleService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SaleService(userId);
            return service;
        }
    }
}