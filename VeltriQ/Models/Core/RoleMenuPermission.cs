namespace VeltriQ.Models.Core
{
    public class RoleMenuPermission
    {
        public int RoleMenuPermissionId { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public bool CanView { get; set; }

        public bool CanAdd { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

        public bool CanApprove { get; set; }

        public bool IsActive { get; set; }

        public DateTime AssignedOn { get; set; }

        public int? AssignedBy { get; set; }

        public virtual AppMenu Menu { get; set; }
    }
}