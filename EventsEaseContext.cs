using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventsEase.Models;

namespace EventsEase.Data
{
    public class EventsEaseContext : DbContext
    {
        public EventsEaseContext(DbContextOptions<EventsEaseContext> options)
            : base(options)
        {
        }

        public DbSet<EventsEase.Models.Venue> Venue { get; set; } = default!;
        public DbSet<EventsEase.Models.Event> Event { get; set; } = default!;
        public DbSet<EventsEase.Models.Booking> Booking { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventType>().HasData(
                new EventType { Id = 1, Name = "Conference" },
                new EventType { Id = 2, Name = "Wedding" },
                new EventType { Id = 3, Name = "Concert" }
            );
        }

        internal object BookingDetails(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
