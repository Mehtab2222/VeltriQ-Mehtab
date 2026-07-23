using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.TransactionApproval
{
    public class TransactionApproval
    {
        [Key]
        public int TransactionApprovalId { get; set; }

        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; } = string.Empty;

        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int RequestedBy { get; set; }

        public int? ApproverId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [StringLength(1000)]
        public string? Remarks { get; set; }

        public DateTime? ActionDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}