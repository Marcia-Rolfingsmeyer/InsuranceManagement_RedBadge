using InsuranceManagement.Models;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateClientService();

            service.CreateClient(model);

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