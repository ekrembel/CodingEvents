using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name of the event is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 - 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        [StringLength(30, ErrorMessage = "Your description must be less than 500 characters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please provide the place of the event")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        public string Place { get; set; }

        [Required]
        [Range(0,100000)]
        public int NumOfAttendees { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Compare("IsTrue", ErrorMessage = "Registration must be required")]
        public bool IsRegistrationRequired { get; set; }

        
        public bool IsTrue { get { return true; } }
    }
}
