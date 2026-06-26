using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeltriQ.Models.HR;

public class State
{
    [Key]
    public int StateId { get; set; }

    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public virtual Country? Country { get; set; }

    [Required]
    [StringLength(100)]
    public string StateName { get; set; } = string.Empty;

    [StringLength(10)]
    public string? StateCode { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [StringLength(450)]
    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    [StringLength(450)]
    public string? ModifiedBy { get; set; }
}