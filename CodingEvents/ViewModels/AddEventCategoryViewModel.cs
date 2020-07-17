using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 - 20 characters.")]
        public string Name { get; set; }
    }
}
