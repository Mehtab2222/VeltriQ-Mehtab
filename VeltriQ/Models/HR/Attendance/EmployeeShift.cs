using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Attendance
{
    public class EmployeeShift
    {
        public int EmployeeShiftId { get; set; }

        public int EmployeeId { get; set; }

        public int ShiftMasterId { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public bool IsCurrent { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        [ForeignKey(nameof(ShiftMasterId))]
        public virtual ShiftMaster? ShiftMaster { get; set; }
    }
}