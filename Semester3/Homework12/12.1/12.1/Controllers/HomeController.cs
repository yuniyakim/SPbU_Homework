using ConferenceRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConferenceRegistration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Time = DateTime.Now;
            return View("MyView");
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
                using (var repository = new Repository())
                {
                    repository.Participants.Add(participant);
                    repository.SaveChanges();
                }
                return View("Thanks", participant);
            }
            return View();
        }

        public IActionResult ListParticipants()
        {
            using (var repository = new Repository())
            {
                return View(repository.Participants.ToList());
            }
        }
    }
}