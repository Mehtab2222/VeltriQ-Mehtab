using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingScheduleViewModel
    {
        public int TrainingScheduleId { get; set; }

        public string? ScheduleCode { get; set; }

        [Required(ErrorMessage = "Please select a training.")]
        [Display(Name = "Training")]
        public int TrainingMasterId { get; set; }

        [Required(ErrorMessage = "Please select a trainer.")]
        [Display(Name = "Trainer")]
        public int TrainingTrainerId { get; set; }

        [Required(ErrorMessage = "Please select a venue.")]
        [Display(Name = "Venue")]
        public int TrainingVenueId { get; set; }

        [Required(ErrorMessage = "Please select a department.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a start date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please select an end date.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string? TrainingDuration { get; set; }
        [Required(ErrorMessage = "Please select a start time.")]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Please select an end time.")]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Last Date")]
        public DateTime? EnrollmentLastDate { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Capacity must be greater than zero.")]
        public int Capacity { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsActive { get; set; } = true;

        // Dropdowns
        public List<SelectListItem> Trainings { get; set; } = new();

        public List<SelectListItem> Trainers { get; set; } = new();

        public List<SelectListItem> Venues { get; set; } = new();

        public List<SelectListItem> Departments { get; set; } = new();
    }
}