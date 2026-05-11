namespace VeltriQ.Models.HR
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public int BranchId { get; set; }

        public string? DepartmentCode { get; set; }

        public string? DepartmentName { get; set; }

        public string? Email { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual ICollection<Designation> Designations { get; set; }
    = new List<Designation>();
    }
}