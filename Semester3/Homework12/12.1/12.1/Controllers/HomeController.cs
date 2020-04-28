using _12._1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _12._1.Controllers
{
    /// <summary>
    /// Web-app controller
    /// </summary>
    public class HomeController : Controller
    {
        private History history;
        private IWebHostEnvironment environment;

        /// <summary>
        /// Controller's constructor
        /// </summary>
        /// <param name="history">History of assemblies and tests</param>
        /// <param name="environment">Web environment</param>
        public HomeController(History history, IWebHostEnvironment environment)
        {
            this.history = history;
            this.environment = environment;
        }

        /// <summary>
        /// Loads start page
        /// </summary>
        public IActionResult Index()
        {
            return View("TestRunner");
        }

        /// <summary>
        /// Uploads file to Files folder
        /// </summary>
        /// <param name="file">Added file</param>
        [HttpPost]
        public IActionResult UploadFIle(IFormFile file)
        {
            if (file != null)
            {
                using (var fileStream = new FileStream(environment.WebRootPath + "/Files/" + file.FileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Participant participant)
        {
            if (ModelState.IsValid)
            {
                using (var repository = new History())
                {
                    repository.Assemblies.Add(participant);
                    repository.SaveChanges();
                }
                return View("Thanks", participant);
            }
            return View();
        }

        public IActionResult ListParticipants()
        {
            using (var repository = new History())
            {
                return View(repository.Assemblies.ToList());
            }
        }
    }
}