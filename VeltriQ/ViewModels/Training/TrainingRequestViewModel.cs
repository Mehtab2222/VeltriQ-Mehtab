using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingRequestViewModel
    {
        public int TrainingRequestId { get; set; }

        [Required(ErrorMessage = "Please select training schedule.")]
        public int TrainingScheduleId { get; set; }

        public string ScheduleCode { get; set; } = string.Empty;

        public string TrainingName { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public string TrainerName { get; set; } = string.Empty;

        public string VenueName { get; set; } = string.Empty;

        public DateTime? TrainingDate { get; set; }

        public int Capacity { get; set; }

        public int TotalEnrolled { get; set; }

        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Please select employee(s).")]
        public string RequestedEmployeeIds { get; set; } = string.Empty;

        public List<int> SelectedEmployeeIds { get; set; } = new();

        public string RequestedEmployeeNames { get; set; } = string.Empty;

        public int RequestedBy { get; set; }

        public DateTime RequestDate { get; set; }

        [StringLength(1000)]
        public string? Reason { get; set; }

        public string Status { get; set; } = string.Empty;

        public IEnumerable<SelectListItem> TrainingSchedules { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Employees { get; set; } = new List<SelectListItem>();
    }
}