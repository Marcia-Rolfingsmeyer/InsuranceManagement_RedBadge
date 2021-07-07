using InsuranceManagement.Models.Auto;
using InsuranceManagement.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagement_RedBadge.Controllers
{
    [Authorize]
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new AutoService(ownerId);
            var model = service.GetAutos();
            
            return View(model);
        }

        //GET : Create/Auto
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create/Auto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutoCreate model)
        {
            if (!ModelState.IsValid) return View (model);

            var service = CreateAutoService();

            if (service.CreateAuto(model))
            {
                TempData["SaveResult"] = "The auto was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Auto was could not be created.");

            return View(model);
        }

        private AutoService CreateAutoService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new AutoService(ownerId);
            return service;
        }


    }
}