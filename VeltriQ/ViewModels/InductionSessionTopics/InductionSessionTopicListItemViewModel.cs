namespace VeltriQ.ViewModels.InductionSessionTopics
{
    public class InductionSessionTopicListItemViewModel
    {
        public int InductionSessionTopicMasterId { get; set; }

        public int DisplayOrder { get; set; }

        public string TopicName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}