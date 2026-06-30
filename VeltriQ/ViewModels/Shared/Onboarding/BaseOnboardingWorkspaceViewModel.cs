using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;

public class BaseOnboardingWorkspaceViewModel
{
    // Header

    public int EmployeeOnboardingId { get; set; }

    public int OnboardingCandidateId { get; set; }

    public string CandidateCode { get; set; } = "";

    public string CandidateName { get; set; } = "";

    public string Email { get; set; } = "";

    public string MobileNumber { get; set; } = "";

    public string Department { get; set; } = "";

    public string Designation { get; set; } = "";

    public string EmploymentType { get; set; } = "";

    public string TemplateName { get; set; } = "";

    public string Status { get; set; } = "";

    public string StatusCode { get; set; } = "";

    public decimal CompletionPercentage { get; set; }

    public bool CanSubmit { get; set; }

    public bool IsPortalLocked { get; set; }

    public DateTime? ExpectedJoiningDate { get; set; }

    // Overview

    public int TotalSections { get; set; }

    public int CompletedSections { get; set; }

    public int TotalDocuments { get; set; }

    public int UploadedDocuments { get; set; }

    public int TotalPolicies { get; set; }

    public int AcceptedPolicies { get; set; }

    // Information

    public List<CandidateOnboardingSectionViewModel> Sections { get; set; } = new();

    // Documents

    public List<EmployeeOnboardingDocumentViewModel> DocumentsList { get; set; } = new();

    // Policies

    public CandidateOnboardingPoliciesViewModel Policies { get; set; } = new();
}