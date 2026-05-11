namespace VeltriQ.Models.HR
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string? CompanyCode { get; set; }

        public string? CompanyName { get; set; }

        public string? ShortName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Website { get; set; }

        public string? TaxNumber { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? StateName { get; set; }

        public string? CountryName { get; set; }

        public string? PostalCode { get; set; }

        public string? LogoPath { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    = new List<Branch>();
    }
}