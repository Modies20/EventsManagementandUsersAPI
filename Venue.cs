using System.ComponentModel.DataAnnotations;

namespace EventsEase.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required] // Ensures the property is validated as non-null
        public string VenueName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        [Required(ErrorMessage = "Venue name is required.")]
        public required string Name { get; set; }

        public bool IsAvailable { get; set; }
    }
}
