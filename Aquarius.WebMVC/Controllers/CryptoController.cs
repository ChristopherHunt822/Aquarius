using Aquarius.Data;
using Aquarius.Models.Crypto;
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
    public class CryptoController : Controller
    {
        // GET: Crypto
        public ActionResult Index()
        {
            var service = CreateCryptoService();
            var model = service.GetCryptos();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCryptoService();

            if (service.CreateCrypto(model))
            {
                TempData["SaveResult"] = "The Crypto was successfully added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Crypto could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCryptoService();
            var model = svc.GetCryptoByID(id);

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateCryptoService();
            var detail = service.GetCryptoByID(id);
            var model =
                new CryptoEdit
                {
                    CryptoID = detail.CryptoID,
                    Name = detail.Name,
                    Symbol = detail.Symbol
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CryptoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CryptoID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCryptoService();

            if (service.UpdateCrypto(model))
            {
                TempData["SaveResult"] = "The Crypto was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Crypto could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCryptoService();
            var model = svc.GetCryptoByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCrypto(int id)
        {
            var service = CreateCryptoService();

            service.DeleteCrypto(id);

            TempData["SaveResult"] = "The Crypto was deleted";

            return RedirectToAction("Index");
        }

        private CryptoService CreateCryptoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CryptoService(userId);
            return service;
        }
    }
}