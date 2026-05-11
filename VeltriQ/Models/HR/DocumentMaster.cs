namespace VeltriQ.Models.HR
{
    public class DocumentMaster
    {
        public int DocumentMasterId { get; set; }

        public string? DocumentCode { get; set; }

        public string? DocumentName { get; set; }

        public string? Description { get; set; }

        public bool IsMandatory { get; set; }

        public string? AllowedFileExtensions { get; set; }

        public int? MaxFileSizeMB { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}