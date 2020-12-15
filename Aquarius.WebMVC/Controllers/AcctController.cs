using Aquarius.Models.Acct;
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
    public class AcctController : Controller
    {
        // GET: Acct
        public ActionResult Index()
        {
            var service = CreateAcctService();
            var model = service.GetAccts();
            return View(model);
        }
        // GET: Create View
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcctCreate model)
        {
            if (!ModelState.IsValid) return View(model);          

            var service = CreateAcctService();

            if (service.CreateAcct(model))
            {
                TempData["SaveResult"] = "The account was successfully created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The account could not be created.");
            return View();
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAcctService();
            var model = svc.GetAcctById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAcctService();
            var detail = service.GetAcctById(id);
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
        public ActionResult Edit(int id, AcctEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InvestorID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAcctService();

            if (service.UpdateAcct(model))
            {
                TempData["SaveResult"] = "The account was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The account could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAcctService();
            var model = svc.GetAcctById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAcct(int id)
        {
            var service = CreateAcctService();

            service.DeleteAcct(id);

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