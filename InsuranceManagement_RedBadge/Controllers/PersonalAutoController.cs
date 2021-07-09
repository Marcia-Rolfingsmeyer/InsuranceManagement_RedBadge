using InsuranceManagement.Models.PersonalAuto;
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
    public class PersonalAutoController : Controller
    {
        // GET: PersonalAuto/Index
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonalAutoService(ownerId);
            var model = service.GetPersonalAutos();

            return View(model);
        }

        //GET : Create/PersonalAuto
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create/PersonalAuto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalAutoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePersonalAutoService();

            if (service.CreatePersonalAuto(model))
            {
                TempData["SaveResult"] = "The auto was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Auto was could not be created.");

            return View(model);
        }

        //GET: Detail/PersonalAuto
        public ActionResult Details(int id)
        {
            var svc = CreatePersonalAutoService();
            var model = svc.GetPersonalAutoById(id);

            return View(model);
        }

        //GET : PersonalAuto/EDIT
        public ActionResult Edit(int id)
        {
            var service = CreatePersonalAutoService();
            var detail = service.GetPersonalAutoById(id);
            var model =
                new PersonalAutoEdit
                {
                    PersonalAutoID = detail.PersonalAutoID,
                    
                    //Auto
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

                    //PersonalAuto
                    IsFullCoverage = detail.IsFullCoverage,
                    IsLiability = detail.IsLiability,
                    IsUninsuredMotorist = detail.IsUninsuredMotorist,
                    IsCarRental = detail.IsCarRental,
                    IsMedicalCoverage = detail.IsMedicalCoverage
                };
            return View(model);
        }

        //POST : PersonalAuto/EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonalAutoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AutoID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePersonalAutoService();

            if (service.UpdatePersonalAuto(model))
            {
                TempData["SaveResult"] = "The auto was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The auto could not be updated.");
            return View(model);
        }

        // GET: PersonalAuto/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePersonalAutoService();
            var model = svc.GetPersonalAutoById(id);

            return View(model);
        }

        // POST : PersonalAuto/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePersonalAutoService();

            service.DeletePersonalAuto(id);

            TempData["SaveResult"] = "The auto was deleted.";

            return RedirectToAction("Index");
        }

        private PersonalAutoService CreatePersonalAutoService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonalAutoService(ownerId);
            return service;
        }
    }
}