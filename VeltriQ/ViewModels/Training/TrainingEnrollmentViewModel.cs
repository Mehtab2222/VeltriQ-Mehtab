using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingEnrollmentViewModel
    {
        public int TrainingEnrollmentId { get; set; }

        [Required(ErrorMessage = "Training Schedule is required.")]
        [Display(Name = "Training Schedule")]
        public int TrainingScheduleId { get; set; }

        [Required(ErrorMessage = "Please select at least one employee.")]
        public List<int> EmployeeIds { get; set; } = new();

        public int? EmployeeId { get; set; }

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Today;

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsActive { get; set; } = true;

        #region Display Properties

        public string? ScheduleCode { get; set; }

        public string? TrainingName { get; set; }

        public string? DepartmentName { get; set; }

        public string? EmployeeCode { get; set; }

        public string? EmployeeName { get; set; }

        public DateTime TrainingDate { get; set; }

        public int Capacity { get; set; }

        public int TotalEnrolled { get; set; }

        public int AvailableSeats => Capacity - TotalEnrolled;

        #endregion

        #region Dropdowns

        public IEnumerable<SelectListItem> TrainingSchedules { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Employees { get; set; } = new List<SelectListItem>();

        #endregion
    }
}