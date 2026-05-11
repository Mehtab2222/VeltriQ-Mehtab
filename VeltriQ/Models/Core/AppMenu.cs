namespace VeltriQ.Models.Core
{
    public class AppMenu
    {
        public int MenuId { get; set; }

        public string? MenuCode { get; set; }

        public string MenuName { get; set; }

        public string? MenuIcon { get; set; }

        public string? AreaName { get; set; }

        public string? ControllerName { get; set; }

        public string? ActionName { get; set; }

        public string? Url { get; set; }

        public int? ParentMenuId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsDropdown { get; set; }

        public bool IsVisible { get; set; }

        public bool IsActive { get; set; }

        public bool OpenInNewTab { get; set; }

        public string? CssClass { get; set; }

        public string? BadgeText { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual ICollection<AppMenu> Children { get; set; }
            = new List<AppMenu>();
    }
}