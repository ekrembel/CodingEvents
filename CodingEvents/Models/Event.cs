using System;
using CodingEvents.ViewModels;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string Place { get; set; }
        public int NumOfAttendees { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int CategoryId { get; set; }
        public EventCategory Category { get; set; }

        public Event()
        {
        }

        public Event(string name, string description, string contactEmail, string place, int numOfAttendees, bool isRegistrationRequired)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            Place = place;
            NumOfAttendees = numOfAttendees;
            IsRegistrationRequired = isRegistrationRequired;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
