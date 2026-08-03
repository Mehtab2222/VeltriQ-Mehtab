using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class AttendancePunch
    {
        public int AttendancePunchId { get; set; }

        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime PunchTime { get; set; }

        public string PunchType { get; set; } = "IN";

        public string AttendanceSource { get; set; } = "Web";

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string? IPAddress { get; set; }

        public string? DeviceName { get; set; }

        public string? SelfiePath { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(AttendanceId))]
        public virtual Attendance? Attendance { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }
    }
}