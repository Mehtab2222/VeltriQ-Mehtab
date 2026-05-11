namespace VeltriQ.Models.HR
{
    public class EmployeeActivity
    {
        public int EmployeeActivityId { get; set; }

        public int EmployeeId { get; set; }

        public string? ActivityType { get; set; }

        public string? ActivityTitle { get; set; }

        public string? ActivityDescription { get; set; }

        public int? ReferenceId { get; set; }

        public string? ReferenceType { get; set; }

        public DateTime ActivityDate { get; set; }

        public string? PerformedBy { get; set; }

        public string? IconClass { get; set; }

        public string? ThemeColor { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}