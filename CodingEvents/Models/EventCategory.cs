using System;
namespace CodingEvents.Models
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class EventCategory
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public EventCategory()
        {
        }

        public EventCategory(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is EventCategory category &&
                   Id == category.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
