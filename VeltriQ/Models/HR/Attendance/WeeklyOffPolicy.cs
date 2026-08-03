using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class WeeklyOffPolicy
    {
        public int WeeklyOffPolicyId { get; set; }

        public int CompanyId { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public DayOfWeek DayOfWeek { get; set; }

        // 0 = Every Week
        // 1 = First
        // 2 = Second
        // 3 = Third
        // 4 = Fourth
        // 5 = Fifth
        public int WeekNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
    }
}