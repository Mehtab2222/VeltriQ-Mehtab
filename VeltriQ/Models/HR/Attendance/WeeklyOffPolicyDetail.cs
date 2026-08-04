using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class WeeklyOffPolicyDetail
    {
        public int WeeklyOffPolicyDetailId { get; set; }

        public int WeeklyOffPolicyId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// 0 = Every Week
        /// 1 = First
        /// 2 = Second
        /// 3 = Third
        /// 4 = Fourth
        /// 5 = Fifth
        /// </summary>
        public int WeekNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(WeeklyOffPolicyId))]
        public virtual WeeklyOffPolicy? WeeklyOffPolicy { get; set; }
    }
}