using System;
using System.Collections.Generic;
using CodingEvents.Models;

namespace CodingEvents.Data
{
    public class EventsData
    {
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();

        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        public static Event GetById(int id)
        {
            return Events[id];
        }

        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        public static void Edit(Event editEvent)
        {
            Events[editEvent.Id].Name = editEvent.Name;
            Events[editEvent.Id].Description = editEvent.Description;
        }
    }
}
