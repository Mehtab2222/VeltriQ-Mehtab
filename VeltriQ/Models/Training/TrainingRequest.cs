using System.ComponentModel.DataAnnotations;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Training
{
    public class TrainingRequest
    {
        [Key]
        public int TrainingRequestId { get; set; }

        [Required]
        [StringLength(20)]
        public string RequestNo { get; set; } = string.Empty;

        [Required]
        public int TrainingScheduleId { get; set; }
        public virtual TrainingSchedule? TrainingSchedule { get; set; }

        // Comma separated Employee Ids
        [Required]
        public string RequestedEmployeeIds { get; set; } = string.Empty;

        [Required]
        public int RequestedBy { get; set; }
        public virtual Employee? RequestedByEmployee { get; set; }

        public DateTime RequestDate { get; set; }

        [StringLength(1000)]
        public string? Reason { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}