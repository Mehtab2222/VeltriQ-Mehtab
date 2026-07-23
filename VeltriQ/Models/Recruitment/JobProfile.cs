using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Recruitment
{
    public class JobProfile
    {
        [Key]
        public int JobProfileId { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public string JobDescription { get; set; }

        public int? ReportingToId { get; set; }
        public int? HiringManagerId { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}