namespace VeltriQ.ViewModels
{
    public class MenuViewModel
    {
        public int MenuId { get; set; }

        public int? ParentMenuId { get; set; }

        public string? MenuName { get; set; }

        public string? MenuIcon { get; set; }

        public string? ControllerName { get; set; }

        public string? ActionName { get; set; }

        public string? Url { get; set; }

        public bool IsDropdown { get; set; }

        public List<MenuViewModel> Children { get; set; }
            = new();
    }
}