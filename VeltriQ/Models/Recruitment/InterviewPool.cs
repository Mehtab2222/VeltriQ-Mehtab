using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

namespace VeltriQ.Models.Recruitment
{
    public class InterviewPool
    {
        [Key]
        public int InterviewPoolId { get; set; }

        [Required]
        [StringLength(100)]
        public string PoolName { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }

        // Screening, Technical Round 1, HR Round, etc.
        [Required]
        public int RoundTypeId { get; set; }

        [ForeignKey(nameof(RoundTypeId))]
        public virtual RoundType? RoundType { get; set; }

        // Optional: Null means this pool can be used by any department.
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        // Optional: Restrict pool to a specific branch if required.
        public int? BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }

        // Future automation support
        public bool AllowAutoAssignment { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual ICollection<InterviewPoolMember> Members { get; set; }
            = new List<InterviewPoolMember>();
    }
}