using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendanceRegularization
    {
        public int AttendanceRegularizationId { get; set; }

        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? RequestedPunchIn { get; set; }

        public DateTime? RequestedPunchOut { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string? HRRemarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(AttendanceId))]
        public virtual Attendance? Attendance { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(ApprovedBy))]
        public virtual Employee? Approver { get; set; }
    }
}