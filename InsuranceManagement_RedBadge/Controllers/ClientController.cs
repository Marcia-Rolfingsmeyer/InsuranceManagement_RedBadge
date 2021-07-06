﻿using InsuranceManagement.Models;
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

        // GET 
        public ActionResult Create()
        {
            return View();
        }

        // Add code here 
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your client was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Client could not be created.");

            return View(model);
        }

        // GET: DETAIL
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        private ClientService CreateClientService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(ownerId);
            return service;
        }
    }
}