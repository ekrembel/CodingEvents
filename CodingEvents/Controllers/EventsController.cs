using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventsDbContext context;

        public EventsController(EventsDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventsData.GetAll());
            List<Event> events = context.Events
                .Include(e => e.Category)
                .ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<EventCategory> categories = context.EventCategory.ToList();
            AddEventViewModel addEventViewModels = new AddEventViewModel(categories);
            return View(addEventViewModels);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.EventCategory.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Place = addEventViewModel.Place,
                    NumOfAttendees = addEventViewModel.NumOfAttendees,
                    IsRegistrationRequired = addEventViewModel.IsRegistrationRequired,
                    Category = theCategory
                };

                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/events");
            }
            return View(addEventViewModel);
            
        }

        [HttpPost]
        [Route("/events")]
        public IActionResult Remove(int eventId)
        {
            Event theEvent = context.Events.Find(eventId);
            context.Events.Remove(theEvent);
            context.SaveChanges();
            
            return Redirect("/events");
        }

        
        public IActionResult Edit(int eventId)
        {
            
            Event theEvent = context.Events.Find(eventId);
            EventCategory category = context.EventCategory.Find(theEvent.CategoryId);
            ViewBag.Category = category;
            ViewBag.Event = theEvent;
            return View();

        }

        [HttpPost]
        public IActionResult Edit(Event editEvent)
        {
            context.Events.Update(editEvent);
            context.SaveChanges();
            return Redirect("/events");

        }

        public IActionResult Detail(int id)
        {
            Event theEvent = context.Events
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);
        }
    }
}
