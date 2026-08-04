using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.HR.Attendance
{
    public class WeeklyOffPolicy
    {
        public int WeeklyOffPolicyId { get; set; }

        public int CompanyId { get; set; }

        public string PolicyCode { get; set; } = string.Empty;

        public string PolicyName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsDefaultPolicy { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        public virtual ICollection<WeeklyOffPolicyDetail> WeeklyOffDetails { get; set; }
            = new List<WeeklyOffPolicyDetail>();
    }
}