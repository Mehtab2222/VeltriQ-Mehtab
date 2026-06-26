using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR
{
    public class City
    {
        public int CityId { get; set; }

        public int CountryId { get; set; }

        public string? CityCode { get; set; }

        public string? CityName { get; set; }

        public string? StateName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Country? Country { get; set; }
        public int? StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        public virtual State? State { get; set; }
    }
}