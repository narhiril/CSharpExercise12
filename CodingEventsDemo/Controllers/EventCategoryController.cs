using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [Route("EventCategory/Create")]
        public IActionResult Create()
        {
            return View(new AddEventCategoryViewModel());
        }

        [HttpPost]
        [Route("EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory 
                { 
                    Name = model.Name,
                };

                context.Add(newCategory);
                context.SaveChanges();
                return Redirect("Index");
            }

            return View();
        }

        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
