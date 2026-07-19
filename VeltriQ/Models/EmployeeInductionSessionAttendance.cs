using VeltriQ.Models.HR;

public class EmployeeInductionSessionAttendance
{
    public int EmployeeInductionSessionAttendanceId { get; set; }

    public int EmployeeInductionSessionId { get; set; }

    public DateTime AttendanceDate { get; set; } = DateTime.Now;

    // 1=Pending 2=Present 3=Absent 4=Late 5=Rescheduled
    public int AttendanceStatus { get; set; }

    public string? Remarks { get; set; }

    public int? TrainerId { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual EmployeeInductionSession? EmployeeInductionSession { get; set; }

    public virtual Employee? Trainer { get; set; }
}