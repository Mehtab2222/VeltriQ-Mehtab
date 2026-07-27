using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string LeaveTypeName { get; set; } = string.Empty; // e.g., Casual Leave, Earned Leave, Sick Leave

        [StringLength(20)]
        public string Code { get; set; } = string.Empty; // e.g., CL, EL, SL

        public int DefaultQuota { get; set; } = 12; // Annual days allocated

        public bool RequiresApproval { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}