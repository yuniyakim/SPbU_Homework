using _12._1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace _12._1.Controllers
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
                using (var repository = new TestHistory())
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
            using (var repository = new TestHistory())
            {
                return View(repository.Participants.ToList());
            }
        }
    }
}