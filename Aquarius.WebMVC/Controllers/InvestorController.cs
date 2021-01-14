using Aquarius.Models.InvestorModels;
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
    public class InvestorController : Controller
    {
        // GET: Investors
        public async Task<ActionResult> Index()
        {
            var service = CreateInvestorService();
            var model = await service.GetInvestorList();

            return View(model);
        }


        // Create: Investor
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvestorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateInvestorService();

            if (await service.CreateInvestor(model))
            {
                TempData["SaveResult"] = "New investor was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Investor could not be created.");

            return View(model);

        }

        public async Task<ActionResult> Details (int id)
        {
            var svc = CreateInvestorService();
            var model = await svc.GetInvestorByID(id);

            return View(model);
        }
       
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateInvestorService();
            var detail = await service.GetInvestorByID(id);
            var model =
                new InvestorEdit
                {
                    InvestorID = detail.InvestorID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, InvestorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.InvestorID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateInvestorService();

            if (await service.UpdateInvestor(model))
            {
                TempData["SaveResult"] = "The investor was updated.";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "The investor could not be updated.");
            return View();
        }
        /*
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = CreateInvestorService();
            var model = await svc.GetInvestorByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteInvestor(int id)
        {
            var service = CreateInvestorService();

            await service.DeleteInvestor(id);

            TempData["SaveResult"] = "The Investor was deleted";

            return RedirectToAction("Index");
        }
        */
        private InvestorService CreateInvestorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InvestorService(userId);
            return service;
        }
    }
}