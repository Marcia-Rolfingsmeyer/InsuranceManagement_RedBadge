using InsuranceManagement.Models.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagement_RedBadge.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {
            var model = new AutoListItem[0];
            return View();
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}