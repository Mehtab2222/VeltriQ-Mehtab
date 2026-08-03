using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class HolidayMaster
    {
        public int HolidayMasterId { get; set; }

        public int CompanyId { get; set; }

        public int? BranchId { get; set; }

        public string HolidayCode { get; set; } = string.Empty;

        public string HolidayName { get; set; } = string.Empty;

        public DateTime HolidayDate { get; set; }

        public bool IsOptional { get; set; }

        public bool IsRecurring { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
    }
}