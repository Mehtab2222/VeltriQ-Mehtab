using VeltriQ.Models.Recruitment;

namespace VeltriQ.ViewModels
{
    public class SkillCategoryGroupViewModel
    {
        public int JobCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SkillMaster> Skills { get; set; } = new();
    }
}