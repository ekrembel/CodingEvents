using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name of the event is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must be between 2 - 50 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [StringLength(30, ErrorMessage = "The name must be less than 30 characters long")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
