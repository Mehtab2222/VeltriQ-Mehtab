namespace VeltriQ.Models.HR
{
    public class Branch
    {
        public int BranchId { get; set; }

        public int CompanyId { get; set; }

        public string? BranchCode { get; set; }

        public string? BranchName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? StateName { get; set; }

        public string? CountryName { get; set; }

        public string? PostalCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    = new List<Department>();
    }
}