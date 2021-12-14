using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_Rental_MVC.Controllers
{
    public class ApiController1 : Controller
    {
        // GET: ApiController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApiController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApiController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApiController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApiController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApiController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
