using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("EmploymentTypeMaster", Schema = "HR")]
    public class EmploymentTypeMaster
    {
        [Key]
        public int EmploymentTypeMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string EmploymentTypeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string EmploymentTypeName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
    }
}