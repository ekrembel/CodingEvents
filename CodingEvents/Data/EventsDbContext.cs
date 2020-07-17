using System;
using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Data
{
    public class EventsDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategory { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTag> EventTags { get; set; }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTag>()
                  .HasKey(et => new { et.EventId, et.TagId });
        }
    }
}
