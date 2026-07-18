using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.InductionSessionTopics
{
    public class InductionSessionTopicViewModel
    {
        public int InductionSessionTopicMasterId { get; set; }

        public int InductionSessionMasterId { get; set; }

        public string ProgramName { get; set; } = string.Empty;

        public string SessionTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Topic name is required.")]
        [StringLength(250)]
        public string TopicName { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;
    }
}