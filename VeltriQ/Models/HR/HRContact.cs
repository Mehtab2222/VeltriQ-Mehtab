namespace VeltriQ.Models.HR
{
    public class HRContact
    {
        public int HRContactId { get; set; }

        public string? ContactCode { get; set; }

        public string? ContactType { get; set; }

        public string? ContactName { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public string? DepartmentName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}