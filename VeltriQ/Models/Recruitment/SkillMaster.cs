using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Recruitment
{
    public class SkillMaster
    {
        [Key]
        public int SkillId { get; set; }

        public int JobCategoryId { get; set; }

        public string SkillName { get; set; }

        public bool IsActive { get; set; }
    }
}