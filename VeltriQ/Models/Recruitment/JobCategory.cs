using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Recruitment
{
    public class JobCategory
    {
        [Key]
        public int JobCategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}