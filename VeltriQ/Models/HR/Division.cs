namespace VeltriQ.Models.HR
{
    public class Division
    {
        public int DivisionId { get; set; }

        public string? DivisionCode { get; set; }

        public string? DivisionName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }
    }
}