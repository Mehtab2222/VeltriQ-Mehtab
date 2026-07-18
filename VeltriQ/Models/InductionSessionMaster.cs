using System.ComponentModel.DataAnnotations;
using VeltriQ.Models.HR;

public class InductionSessionMaster
{
    public int InductionSessionMasterId { get; set; }

    public int InductionProgramMasterId { get; set; }

    [Required]
    [StringLength(20)]
    public string SessionCode { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string SessionTitle { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public int SessionOrder { get; set; }

    public int DurationInMinutes { get; set; }

    public bool IsMandatory { get; set; } = true;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [StringLength(100)]
    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    [StringLength(100)]
    public string? ModifiedBy { get; set; }

    public virtual InductionProgramMaster? InductionProgramMaster { get; set; }
}