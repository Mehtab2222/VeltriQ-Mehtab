namespace VeltriQ.Models.Common
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public long? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}
