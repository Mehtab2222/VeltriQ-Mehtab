using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels
{
    public class JobProfileViewModel
    {
        public int JobProfileId { get; set; }

        public string JobTitle { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public string JobDescription { get; set; }

        public string RequiredSkills { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public int? MinExperience { get; set; }

        public int? MaxExperience { get; set; }
        public int JobCategoryId { get; set; }

        public List<int> SelectedSkillIds { get; set; }

        public List<SelectListItem>? JobCategoryList { get; set; }

        public List<SelectListItem>? SkillList { get; set; }
        public List<SelectListItem>? DepartmentList { get; set; }

        public List<SelectListItem>? DesignationList { get; set; }
    }
}