using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.HR
{
    public class InductionSessionTopicMaster
    {
        public int InductionSessionTopicMasterId { get; set; }

        public int InductionSessionMasterId { get; set; }

        [Required]
        [StringLength(250)]
        public string TopicName { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public virtual InductionSessionMaster? InductionSessionMaster { get; set; }
    }
}