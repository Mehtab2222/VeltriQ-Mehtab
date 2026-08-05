using System.ComponentModel.DataAnnotations.Schema;

namespace VeltriQ.Models.HR.Attendance
{
    public class HolidayMaster
    {
        public int HolidayMasterId { get; set; }

        //====================================================
        // BASIC INFORMATION
        //====================================================

        public int CompanyId { get; set; }

        public int? BranchId { get; set; }

        public string HolidayCode { get; set; } = string.Empty;

        public string HolidayName { get; set; } = string.Empty;

        public DateTime HolidayDate { get; set; }

        public string HolidayType { get; set; } = string.Empty;

        public string? Description { get; set; }

        //====================================================
        // HOLIDAY SETTINGS
        //====================================================

        public bool IsOptional { get; set; }

        public bool IsRecurring { get; set; }

        public bool IsHalfDay { get; set; }

        /// <summary>
        /// Morning / Afternoon
        /// </summary>
        public string? HalfDaySession { get; set; }

        //====================================================
        // STATUS
        //====================================================

        public bool IsActive { get; set; } = true;

        //====================================================
        // AUDIT
        //====================================================

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        //====================================================
        // NAVIGATION
        //====================================================

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
    }
}