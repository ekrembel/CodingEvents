using System;
namespace CodingEvents.Models
{
    public class Event
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public static int nextId = 1;
        public string ContactEmail { get; set; }
        public string Place { get; set; }
        public int NumOfAttendees { get; set; }
        public bool IsRegistrationRequired { get; set; }

        public Event()
        {
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description, string contactEmail, string place, int numOfAttendees, bool isRegistrationRequired) : this()
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
