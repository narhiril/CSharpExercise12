﻿using CodingEventsDemo.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsDemo.ViewModels
{
    public class EventDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }

        public string TagText { get; set; }

        public int EventId { get; set; }

        public EventDetailViewModel(Event theEvent, List<EventTag> eventTags)
        {
            EventId = theEvent.Id;
            Name = theEvent.Name;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;
            TagText = string.Join(", ",
                from tag in eventTags
                select $"#{tag.Tag.Name}"
                );
        }
    }
}
