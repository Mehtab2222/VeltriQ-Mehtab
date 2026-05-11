namespace VeltriQ.Models.HR
{
    public class Country
    {
        public int CountryId { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public string? CurrencyCode { get; set; }

        public string? PhoneCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual ICollection<City> Cities { get; set; }
            = new List<City>();
    }
}