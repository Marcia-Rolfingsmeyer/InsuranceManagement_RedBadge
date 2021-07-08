using InsuranceManagement.Models;
using InsuranceManagement.Models.Client;
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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(ownerId);
            var model = service.GetClients();

            return View(model);
        }

        // GET : Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create/Client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "The client was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The client could not be created.");

            return View(model);
        }

        // GET: DETAIL/Client
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        // GET: EDIT/Client
        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientID = detail.ClientID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Phone = detail.Phone,
                    Email = detail.Email,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State
                };
            return View(model);
        }

        // POST : Edit/Client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "The client was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The client could not be updated.");
            return View(model);
        }

        // GET: Delete/Client
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        // POST: Delete/Client
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();
            
            service.DeleteClient(id);

            TempData["SaveResult"] = "The client was deleted.";
            
            return RedirectToAction("Index");
        }

        private ClientService CreateClientService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(ownerId);
            return service;
        }
    }
}