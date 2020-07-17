using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the tag.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tag must be between 3 - 20 characters.")]
        public string Name { get; set; }

        public Tag(string name)
        {
            Name = name;
        }
        public Tag()
        {
        }
    }
}
