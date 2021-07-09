using InsuranceManagement.Models.CommercialAuto;
using InsuranceManagement.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagement_RedBadge.Controllers
{
    public class CommercialAutoController : Controller
    {
        // GET: CommercialAuto
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommercialAutoService(ownerId);
            var model = service.GetCommercialAutos();

            return View(model);
        }

        //GET : Create/CommercialAuto
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create/CommercialAuto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommercialAutoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCommercialAutoService();

            if (service.CreateCommercialAuto(model))
            {
                TempData["SaveResult"] = "The auto was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Auto was could not be created.");

            return View(model);
        }

        //GET: Detail/CommercialAuto
        public ActionResult Details(int id)
        {
            var svc = CreateCommercialAutoService();
            var model = svc.GetCommercialAutoById(id);

            return View(model);
        }

        //GET : CommercialAuto/EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateCommercialAutoService();
            var detail = service.GetCommercialAutoById(id);
            var model =
                new CommercialAutoEdit
                {

                    //CommercialAuto
                    CommercialAutoID = detail.CommercialAutoID,
                    NumberInFleet = detail.NumberInFleet,

                    /*This Section build method to make         multiple vehicles
                      * 
                      * Make = entity.Make,
                        CarModel = entity.CarModel,
                        Year = entity.Year,
                        Mileage = entity.Mileage,
                        VINNumber = entity.VINNumber,*/

                    NumberOfDrivers = detail.NumberOfDrivers,
                    DOTNumber = detail.DOTNumber,
                    RadiusOfOperation = detail.RadiusOfOperation,
                    CompDeductible = detail.CompDeductible,
                    CollisionDeductible = detail.CollisionDeductible,

                    //Auto
                    CurrentCarrier = detail.CurrentCarrier,
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

        //POST : CommercialAuto/EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommercialAutoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AutoID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCommercialAutoService();

            if (service.UpdateCommercialAuto(model))
            {
                TempData["SaveResult"] = "The auto was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The auto could not be updated.");
            return View(model);
        }

        // GET: CommercialAuto/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCommercialAutoService();
            var model = svc.GetCommercialAutoById(id);

            return View(model);
        }

        // POST : CommercialAuto/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCommercialAutoService();

            service.DeleteCommercialAuto(id);

            TempData["SaveResult"] = "The auto was deleted.";

            return RedirectToAction("Index");
        }

        private CommercialAutoService CreateCommercialAutoService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommercialAutoService(ownerId);
            return service;
        }
    }
}