namespace VeltriQ.ViewModels.Recruitment
{
    public class InterviewPoolListItemViewModel
    {
        public int InterviewPoolId { get; set; }

        public string PoolName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string RoundTypeName { get; set; } = string.Empty;

        public string? DepartmentName { get; set; }

        public string? BranchName { get; set; }

        public int MemberCount { get; set; }
    }

    public class CreateInterviewPoolDto
    {
        public string PoolName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int RoundTypeId { get; set; }

        public int? DepartmentId { get; set; }

        public int? BranchId { get; set; }
    }

    public class UpdateInterviewPoolDto
    {
        public int InterviewPoolId { get; set; }

        public string PoolName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int RoundTypeId { get; set; }

        public int? DepartmentId { get; set; }

        public int? BranchId { get; set; }
    }
}