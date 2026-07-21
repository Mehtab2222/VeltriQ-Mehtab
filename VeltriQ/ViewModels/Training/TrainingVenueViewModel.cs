using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingVenueViewModel
    {
        public int TrainingVenueId { get; set; }

        public string? VenueCode { get; set; }

        [Required(ErrorMessage = "Venue Name is required.")]
        [StringLength(200)]
        public string VenueName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select venue type.")]
        public byte VenueType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than zero.")]
        public int? Capacity { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        // Venue Type Dropdown
        public List<SelectListItem> VenueTypes { get; set; } = new()
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Internal"
            },
            new SelectListItem
            {
                Value = "2",
                Text = "External"
            },
            new SelectListItem
            {
                Value = "3",
                Text = "Online"
            }
        };
    }
}