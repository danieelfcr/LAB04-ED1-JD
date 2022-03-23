using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace LAB04_ED1.Controllers
{
    public class PriorityQueueController : Controller
    {
        // GET: PriorityQueueController
        public ActionResult Index(List<Patient> list)
        {
            return View(list);
        }

        // GET: PriorityQueueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PriorityQueueController/Create
        public ActionResult Create()
        {
            return View(new Patient());
        }

        // POST: PriorityQueueController/Create
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

        // GET: PriorityQueueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PriorityQueueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Patient patient = new Patient
                {
                    Names = collection["Names"],
                    LastNames = collection["LastNames"],
                    Age = Convert.ToInt16(collection["BirthDate"]),
                    Sex = collection["Sex"],
                    Specialization = collection["Specialization"],
                    EntryMethod = collection["Names"],
                    EntryDate = Convert.ToDateTime(collection["EntryDate"])
                };
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PriorityQueueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PriorityQueueController/Delete/5
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
