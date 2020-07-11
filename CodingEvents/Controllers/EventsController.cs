using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventsData.GetAll());
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModels = new AddEventViewModel();
            return View(addEventViewModels);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail
                };
                EventsData.Add(newEvent);
                return Redirect("/events");
            }
            return View(addEventViewModel);
            
        }

        [HttpPost]
        [Route("/events")]
        public IActionResult Remove(int eventId)
        {

            EventsData.Remove(eventId);
            return Redirect("/events");
        }

        
        public IActionResult Edit(int eventId)
        {
            ViewBag.Event = EventsData.GetById(eventId);
            return View();

        }

        [HttpPost]
        public IActionResult Edit(Event editEvent)
        {
            EventsData.Edit(editEvent);
            return Redirect("/events");

        }
    }
}
