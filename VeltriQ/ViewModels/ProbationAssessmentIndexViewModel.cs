using System;

namespace VeltriQ.ViewModels.HR
{
    public class ProbationAssessmentIndexViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string? OfficialEmail { get; set; }

        public string Department { get; set; } = "-";

        public string Designation { get; set; } = "-";

        public DateTime? JoiningDate { get; set; }

        public DateTime? ProbationEndDate { get; set; }

        public int? AssessmentId { get; set; }

        public string OverallStatus { get; set; } = "Not Started";

        public bool HasAssessment { get; set; }

        public string? CurrentCheckpointLabel { get; set; }

        public DateTime? CurrentCheckpointDate { get; set; }

        public int? DaysRemaining { get; set; }
    }
}