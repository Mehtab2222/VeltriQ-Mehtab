namespace VeltriQ.Models.HR
{
    public class EmployeeDocument
    {
        public int EmployeeDocumentId { get; set; }

        public int EmployeeId { get; set; }

        public int DocumentMasterId { get; set; }

        public string? DocumentNumber { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string? VerificationStatus { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual DocumentMaster? DocumentMaster { get; set; }
    }
}