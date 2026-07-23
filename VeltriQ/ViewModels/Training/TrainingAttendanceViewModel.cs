using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingAttendanceViewModel
    {
        public int TrainingAttendanceId { get; set; }

        public int TrainingScheduleId { get; set; }

        public int EmployeeId { get; set; }

        // ✅ NEW: The specific date being marked
        public DateTime SelectedAttendanceDate { get; set; } = DateTime.Today;

        public string? AttendanceStatus { get; set; }

        public DateTime? AttendanceTime { get; set; }

        public string? Remarks { get; set; }

        public bool IsActive { get; set; }

        // ===========================
        // Display Properties
        // ===========================

        public string? ScheduleCode { get; set; }

        public string? TrainingName { get; set; }

        public string? DepartmentName { get; set; }

        public string? TrainerName { get; set; }

        public string? VenueName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? EmployeeCode { get; set; }

        public string? EmployeeName { get; set; }

        public int Capacity { get; set; }

        public int TotalEnrolled { get; set; }

        public int PresentCount { get; set; }

        public int AbsentCount { get; set; }

        public int LateCount { get; set; }

        public IEnumerable<SelectListItem>? TrainingSchedules { get; set; }

        public IEnumerable<SelectListItem>? Employees { get; set; }
    }
}