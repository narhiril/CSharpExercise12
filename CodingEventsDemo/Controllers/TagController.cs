using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsDemo.Controllers
{
    public class TagController : Controller
    {
        private EventDbContext context;

        public TagController(EventDbContext dbContext) 
        {
            context = dbContext;
        }

        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = (
                from tagEntry in context.EventTags.Include(x => x.Tag)
                select new Tag
                {
                    Id = tagEntry.TagId,
                    Name = tagEntry.Tag.Name
                }).ToList();
            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                EventTag eventTag = new EventTag
                {
                    EventId = eventId,
                    TagId = tagId
                };
                context.EventTags.Add(eventTag);
                context.SaveChanges();

                return Redirect("/Events/Detail/" + eventId);
            }

            return View(viewModel);
        }
    }
}
