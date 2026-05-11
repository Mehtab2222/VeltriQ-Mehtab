namespace VeltriQ.Models.HR
{
    public class Designation
    {
        public int DesignationId { get; set; }

        public int DepartmentId { get; set; }

        public string? DesignationCode { get; set; }

        public string? DesignationName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Department? Department { get; set; }
    }
}