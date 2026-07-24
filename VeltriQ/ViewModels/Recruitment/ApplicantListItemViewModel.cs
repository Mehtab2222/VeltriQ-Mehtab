using Microsoft.AspNetCore.Http;

namespace VeltriQ.ViewModels.Recruitment
{
    // Applicant/Index grid row
    public class ApplicantListItemViewModel
    {
        public int ApplicantId { get; set; }
        public string ApplicantCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MprCode { get; set; } = string.Empty;
        public string MprTitle { get; set; } = string.Empty;
        public int? MatchPercentage { get; set; }
        public decimal TotalExperience { get; set; }
        public DateTime AppliedOn { get; set; }
        public string CurrentStage { get; set; } = string.Empty;
        public string? SourceType { get; set; }
    }

    // Applicant/Create form submission (multipart — has a file)
    public class ApplicantCreateViewModel
    {
        public int ManpowerRequestId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? SourceType { get; set; }
        public decimal TotalExperience { get; set; }
        public decimal? RelevantExperience { get; set; }
        public int? MatchPercentage { get; set; }
        public IFormFile? ResumeFile { get; set; }
    }

    // Hiring pipeline row (per stage tab)
    public class HiringCandidateViewModel
    {
        public int ApplicantId { get; set; }
        public string ApplicantCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MprCode { get; set; } = string.Empty;
        public string MprTitle { get; set; } = string.Empty;
        public int? MatchPercentage { get; set; }
        public decimal TotalExperience { get; set; }
        public DateTime AppliedOn { get; set; }
        public string CurrentStage { get; set; } = string.Empty;
        public int DaysInStage { get; set; }
        public string? HiringManagerName { get; set; }
    }
}