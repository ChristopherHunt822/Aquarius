using Aquarius.Data;
using Aquarius.Models.AcctModels;
using Aquarius.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aquarius.WebMVC.Controllers
{
    [Authorize]
    public class AcctController : Controller
    {
        // GET: Acct
        public async Task<ActionResult> Index()
        {
            var service = CreateAcctService();
            var model = await service.GetAcctList();
            return View(model);
        }
        // GET: Create View
        public ActionResult Create()
        {
            List<Investor> Investors = (new InvestorService()).GetInvestors().ToList();
            var query = from i in Investors
                        select new SelectListItem()
                        {
                            Value = i.InvestorID.ToString(),
                            Text = i.FullName
                        };
            ViewBag.InvestorID = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AcctCreate model)
        {
            if (!ModelState.IsValid) return View(model);          

            var service = CreateAcctService();

            if (await service.CreateAcct(model))
            {
                TempData["SaveResult"] = "The account was successfully created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The account could not be created.");
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var svc = CreateAcctService();
            var model = await svc.GetAcctById(id);

            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateAcctService();
            var detail = await service.GetAcctById(id);
            var model =
                new AcctEdit
                {
                    AcctID = detail.AcctID,
                    AcctType = (AcctEdit.AcctTypeEnum)detail.AcctType,
                    InvestorID = detail.InvestorID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AcctEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InvestorID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAcctService();

            if (await service.UpdateAcct(model))
            {
                TempData["SaveResult"] = "The account was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The account could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = CreateAcctService();
            var model = await svc.GetAcctById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAcct(int id)
        {
            var service = CreateAcctService();

            await service.DeleteAcct(id);

            TempData["SaveResult"] = "The Account was deleted";

            return RedirectToAction("Index");
        }
        private AcctService CreateAcctService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AcctService(userId);
            return service;
        }


    }
}