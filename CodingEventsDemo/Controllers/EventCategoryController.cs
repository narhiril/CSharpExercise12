using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
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

        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
