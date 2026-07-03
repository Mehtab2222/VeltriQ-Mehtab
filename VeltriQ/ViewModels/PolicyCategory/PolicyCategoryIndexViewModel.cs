using VeltriQ.ViewModels.PolicyCategory;

namespace VeltriQ.ViewModels.PolicyCategory
{
    public class PolicyCategoryIndexViewModel
    {
        public string SearchText { get; set; } = "";

        public PolicyCategoryCreateViewModel CreateCategory { get; set; }
            = new();

        public List<PolicyCategoryListItemViewModel> Categories { get; set; }
            = new();
    }
}