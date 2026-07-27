using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.Recruitment
{
    public class AvailabilitySlot
    {
        [Key]
        public int AvailabilitySlotId { get; set; }

        [Required]
        public int AvailabilityRequestId { get; set; }
        [ForeignKey(nameof(AvailabilityRequestId))]
        public virtual AvailabilityRequest? AvailabilityRequest { get; set; }

        [Required]
        public DateTime SlotDateTime { get; set; } // TargetDate + the specific time offered

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
    }
}