using System.ComponentModel.DataAnnotations;

namespace EventsEase.Models
{
    public class EventType
    {
        public int Id { get; set; }
        [Required]  // This attribute ensures the Name property is mandatory
        public string Name { get; set; }  // e.g., "Conference", "Wedding"
    }
}
