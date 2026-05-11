namespace VeltriQ.Models.HR
{
    public class Nationality
    {
        public int NationalityId { get; set; }

        public string? NationalityCode { get; set; }

        public string? NationalityName { get; set; }

        public string? CountryCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}