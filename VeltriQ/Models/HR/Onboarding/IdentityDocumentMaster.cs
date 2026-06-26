using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Onboarding
{
    [Table("IdentityDocumentMaster", Schema = "HR")]
    public class IdentityDocumentMaster
    {
        [Key]
        public int IdentityDocumentMasterId { get; set; }

        [Required]
        [StringLength(20)]
        public string DocumentCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        // Example:
        // India, UAE, USA
        [StringLength(100)]
        public string? CountryName { get; set; }

        public bool HasExpiry { get; set; }

        public bool IsMandatory { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(450)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(450)]
        public string? ModifiedBy { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country? Country { get; set; }
    }
}