namespace VeltriQ.ViewModels.PolicyCategory
{
    public class PolicyCategoryListItemViewModel
    {
        public int OnboardingPolicyCategoryMasterId { get; set; }

        public string CategoryName { get; set; } = "";

        public string Description { get; set; } = "";

        public int DisplayOrder { get; set; }

        public int PolicyCount { get; set; }

        public bool IsActive { get; set; }
    }
}