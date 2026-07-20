using VeltriQ.Models.HR;

namespace VeltriQ.Models.EmployeeInductionAttendance
{
    public class EmployeeInductionAttendance
    {
        public int EmployeeInductionAttendanceId { get; set; }

        public int InductionProgramMasterId { get; set; }

        public int InductionSessionMasterId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsLocked { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual InductionProgramMaster InductionProgramMaster { get; set; }

        public virtual InductionSessionMaster InductionSessionMaster { get; set; }

        public virtual ICollection<EmployeeInductionAttendanceDetail> AttendanceDetails { get; set; }
            = new List<EmployeeInductionAttendanceDetail>();
    }
}
