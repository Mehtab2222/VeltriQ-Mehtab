using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }

        [ForeignKey(nameof(LeaveTypeId))]
        public virtual LeaveType? LeaveType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal TotalDays { get; set; }

        [Required]
        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        [StringLength(500)]
        public string? ManagerRemarks { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }
    }
}