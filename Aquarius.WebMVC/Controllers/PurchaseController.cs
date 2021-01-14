using Aquarius.Data;
using Aquarius.Models.PurchaseModels;
using Aquarius.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aquarius.WebMVC.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public async Task<ActionResult> Index()
        {
            var service = CreatePurchaseService();
            var model = await service.GetPurchases();
            return View(model);
        }
        // GET: Purchase View
        public ActionResult Create()
        {
            List<Acct> Accts = (new AcctService()).GetAccts().ToList();
            var query = from a in Accts
                        select new SelectListItem()
                        {
                            Value = a.AcctID.ToString(),
                            Text = a.AcctName
                        };
            ViewBag.AcctID = query.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PurchaseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePurchaseService();

            if (await service.CreatePurchase(model))
            {
                TempData["SaveResult"] = "The purchase was succesfully made.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The purchase could not be completed, please try again.");
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var svc = CreatePurchaseService();
            var model = await svc.GetPurchaseById(id);

            return View(model);
        }
        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
    }
}