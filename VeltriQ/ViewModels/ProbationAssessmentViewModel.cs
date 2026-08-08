using System.Collections.Generic;
using VeltriQ.Models.HR.ProbationAssessment;

namespace VeltriQ.ViewModels.HR
{
    public class ProbationAssessmentViewModel
    {
        public ProbationAssessmentMasterModel Master { get; set; } = new();
        public List<ProbationAssessmentDetailsModel> Checkpoints { get; set; } = new();
        public ProbationAssessmentDetailsModel? ActiveCheckpoint { get; set; }
        public int ActiveCheckpointIndex { get; set; }
        public List<ProbationCriteriaMaster> AllCriteria { get; set; } = new();
        public List<ProbationAssessmentRatingsModel> ActiveRatings { get; set; } = new();
        public List<ProbationExtensionLogModel> ExtensionHistory { get; set; } = new();
        public string CompanyId { get; set; } = string.Empty;
        public bool IsHR { get; set; }
        public bool IsManager { get; set; }
    }
}