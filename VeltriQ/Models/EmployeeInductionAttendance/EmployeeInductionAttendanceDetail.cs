using VeltriQ.Models.HR;

namespace VeltriQ.Models.EmployeeInductionAttendance
{
    public class EmployeeInductionAttendanceDetail
    {
        public int EmployeeInductionAttendanceDetailId { get; set; }

        public int EmployeeInductionAttendanceId { get; set; }

        // Employee Induction Record
        public int EmployeeInductionId { get; set; }

        // Assigned Session of that Employee
        public int EmployeeInductionSessionId { get; set; }

        /// <summary>
        /// 1 = Present
        /// 2 = Absent
        /// 3 = Late
        /// 4 = Rescheduled
        /// </summary>
        public int AttendanceStatus { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        #region Navigation Properties

        public virtual EmployeeInductionAttendance EmployeeInductionAttendance { get; set; } = null!;

        public virtual EmployeeInduction EmployeeInduction { get; set; } = null!;

        public virtual EmployeeInductionSession EmployeeInductionSession { get; set; } = null!;

        #endregion
    }
}