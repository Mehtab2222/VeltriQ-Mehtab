using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels
{
    public class ManpowerRequestViewModel
    {
        public int ManpowerRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public int RecruitmentTypeId { get; set; }

        public int? HODId { get; set; }

        public int DepartmentId { get; set; }

        public int BranchId { get; set; }

        public int? DivisionId { get; set; }
        public int DesignationId { get; set; }

        public int? ReplacementEmployeeId { get; set; }

        public int NumberOfPositions { get; set; }

        public DateTime? RequiredJoiningDate { get; set; }

        public decimal? MinExperience { get; set; }

        public decimal? MaxExperience { get; set; }

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public int? EducationId { get; set; }

        public int? NationalityId { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public int? PriorityId { get; set; }

        public string JobDescription { get; set; }

        public string RequiredSkills { get; set; }

        public string Remarks { get; set; }

        public IEnumerable<SelectListItem> RecruitmentTypes { get; set; }

        public IEnumerable<SelectListItem> HODList { get; set; }

        public IEnumerable<SelectListItem> BranchList { get; set; }

        public IEnumerable<SelectListItem> DivisionList { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }

        public IEnumerable<SelectListItem> DesignationList { get; set; }

        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        public IEnumerable<SelectListItem> EducationList { get; set; }

        public IEnumerable<SelectListItem> NationalityList { get; set; }

        public IEnumerable<SelectListItem> PriorityList { get; set; }
    }
}
