using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 50 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Number of expected attendees required.")]
        [Range(0, 1e5, ErrorMessage = "Number of attendees must be a whole number between 0 and 100,000.")]
        public int Attendees { get; set; }

        [Required]
        [Compare("IsTrue", ErrorMessage = "You thought this was optional, didn't you?")]
        public bool IsRegistrationRequired { get; set; }

        public bool IsTrue { get { return true; } }

    }
}
