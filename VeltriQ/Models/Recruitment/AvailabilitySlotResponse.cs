using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Recruitment
{
    public class AvailabilitySlotResponse
    {
        [Key]
        public int AvailabilitySlotResponseId { get; set; }

        [Required]
        public int AvailabilitySlotId { get; set; }
        [ForeignKey(nameof(AvailabilitySlotId))]
        public virtual AvailabilitySlot? AvailabilitySlot { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [Required]
        public DateTime RespondedOn { get; set; }

        public bool IsActive { get; set; } = true;
    }
}