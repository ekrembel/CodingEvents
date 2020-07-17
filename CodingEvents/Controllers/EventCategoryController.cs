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
    public class EventCategoryController : Controller
    {
        private EventsDbContext context;

        public EventCategoryController(EventsDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<EventCategory> categories = context.EventCategory.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory eventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                };

                context.EventCategory.Add(eventCategory);
                context.SaveChanges();
                return Redirect("/eventcategory");
            }

            return View(addEventCategoryViewModel);
        }
    }
}
