using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using LAB04_ED1.Helpers;


namespace LAB04_ED1.Controllers
{
    public class PriorityQueueController : Controller
    {
        public static Func<Patient, int> PriorityCalculator = (patient) =>
        {
            int priority = 0;
            if (patient.Sex == "Male")
                priority += 3;
            else
                priority += 5;

            if (patient.Age >= 70)
                priority += 10;
            else if (patient.Age >= 50 && patient.Age <= 69)
                priority += 8;
            else if (patient.Age >= 18 && patient.Age <= 49)
                priority += 3;
            else if (patient.Age >= 6 && patient.Age <= 17)
                priority += 5;
            else if (patient.Age >= 0 && patient.Age <= 5)
                priority += 8;

            switch (patient.Specialization)
            {
                case "Internal traumatology":
                    priority += 3;
                    break;
                case "Exposed traumatology":
                    priority += 8;
                    break;
                case "Gynecology":
                    priority += 5;
                    break;
                case "Cardiology":
                    priority += 10;
                    break;
                case "Pneumology":
                    priority += 8;
                    break;
            }

            if (patient.EntryMethod == "Ambulance")
                priority += 5;
            else
                priority += 3;

            return priority;

        };







        // GET: PriorityQueueController
        public ActionResult Index()
        {
            Data.Instance.OutputPatientQueue = Data.Instance.PatientQueue.deepCopy();
            Data.Instance.OutputPatientQueue.swapNodes = Data.Instance.PatientQueue.swapNodes;
            Data.Instance.OutputPatientQueue.PriorityComparer = Data.Instance.PatientQueue.PriorityComparer;
            
            return View(Data.Instance.OutputPatientQueue.GetNodeList(Data.Instance.OutputPatientQueue.Root));  
        }

       
        public IActionResult Peek()
        {
            if (Data.Instance.PatientQueue.IsEmpty())
                return View();
            else
            {
                List<Patient> aux = new List<Patient>();
                aux.Add(Data.Instance.PatientQueue.Peek().Record);
                return View(aux);
            }
                
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
                Patient patient = new Patient
                {
                  
                    Names = collection["Names"],
                    LastNames = collection["LastNames"],
                    BirthDate = Convert.ToDateTime(collection["BirthDate"]),
                    Age = (DateTime.Now.Year - Convert.ToDateTime(collection["BirthDate"]).Year),
                    Sex = collection["Sex"],
                    Specialization = collection["Specialization"],
                    EntryMethod = collection["EntryMethod"],
                    EntryDate = Convert.ToDateTime(collection["EntryDate"]),
                    EntryTime = collection["EntryTime"]
                };

                patient.Priority = PriorityCalculator(patient);

                Node<Patient> NewNode = new Node<Patient>(patient);
                NewNode.IsNull = 0;
                Data.Instance.PatientQueue.Root = Data.Instance.PatientQueue.Add(Data.Instance.PatientQueue.Root, NewNode);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Remove()
        {
            Data.Instance.PatientQueue.Remove();
           

            return RedirectToAction(nameof(Index));
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
