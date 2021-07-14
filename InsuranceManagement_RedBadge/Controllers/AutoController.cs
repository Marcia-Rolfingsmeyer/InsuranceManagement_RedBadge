/*using InsuranceManagement.Models.Auto;
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

        //GET: Detail/Auto
        public ActionResult Details(int id)
        {
            var svc = CreateAutoService();
            var model = svc.GetAutoById(id);

            return View(model);
        }

        //GET : Auto/EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateAutoService();
            var detail = service.GetAutoById(id);
            var model =
                new AutoEdit
                {
                    AutoID = detail.AutoID,
                    Make = detail.Make,
                    CarModel = detail.CarModel,
                    Year = detail.Year,
                    Mileage = detail.Mileage,
                    VINNumber = detail.VINNumber,
                    CurrentCarrier = detail.CurrentCarrier,
                    CurrentDeductible = detail.CurrentDeductible,
                    PolicyNumber = detail.PolicyNumber,
                    PolicyStartDate = detail.PolicyStartDate,
                    PolicyEndDate = detail.PolicyEndDate,
                    LiabilityLimit = detail.LiabilityLimit,
                    LossesLastFiveYears = detail.LossesLastFiveYears,
                    YearOfLoss = detail.YearOfLoss,
                    ClaimsLastFiveYears = detail.ClaimsLastFiveYears,
                    AmountOfClaim = detail.AmountOfClaim,
                    YearOfClaim = detail.YearOfClaim,
                };
            return View(model);
        }

        //POST : Auto/EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AutoID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAutoService();

            if (service.UpdateAuto(model))
            {
                TempData["SaveResult"] = "The auto was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The auto could not be updated.");
            return View(model);
        }

        // GET: Auto/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAutoService();
            var model = svc.GetAutoById(id);

            return View(model);
        }

        // POST : Auto/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAutoService();

            service.DeleteAuto(id);

            TempData["SaveResult"] = "The auto was deleted.";

            return RedirectToAction("Index");
        }

        private AutoService CreateAutoService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new AutoService(ownerId);
            return service;
        }
    }
}*/