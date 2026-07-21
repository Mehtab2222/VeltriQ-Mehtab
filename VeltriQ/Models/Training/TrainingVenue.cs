using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Training
{
    public class TrainingVenue
    {
        [Key]
        public int TrainingVenueId { get; set; }

        [Required]
        [StringLength(20)]
        public string VenueCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string VenueName { get; set; } = string.Empty;

        // 1 = Internal, 2 = External, 3 = Online
        [Required]
        public byte VenueType { get; set; }

        public int? Capacity { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}