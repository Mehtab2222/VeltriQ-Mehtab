using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels
{
    public class JobProfileViewModel
    {
        public int JobProfileId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public int JobCategoryId { get; set; }
        public List<int> SelectedSkillIds { get; set; } = new();
        public List<int> SelectedReviewerIds { get; set; } = new();

        public int? ReportingToId { get; set; }
        public int? HiringManagerId { get; set; }

        public List<SelectListItem>? JobCategoryList { get; set; }
        public List<SelectListItem>? SkillList { get; set; }
        public List<SelectListItem>? EmployeeList { get; set; }
    }
}