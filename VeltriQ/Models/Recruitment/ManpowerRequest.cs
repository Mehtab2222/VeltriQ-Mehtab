using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.Recruitment
{
    [Table("ManpowerRequest", Schema = "Recruitment")]
    public class ManpowerRequest
    {
        [Key]
        public int ManpowerRequestId { get; set; }

        public string RequestCode { get; set; }

        public DateTime RequestDate { get; set; }

        public int RecruitmentTypeId { get; set; }

        public int? HODId { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public int? ReplacementEmployeeId { get; set; }

        public int NumberOfPositions { get; set; }

        public DateTime? RequiredJoiningDate { get; set; }

        public decimal? MinExperience { get; set; }

        public decimal? MaxExperience { get; set; }

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public int? EducationId { get; set; }

        public int? NationalityId { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public int? PriorityId { get; set; }

        public string? JobDescription { get; set; }

        public string? RequiredSkills { get; set; }

        public string? Remarks { get; set; }

        public int StatusId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}