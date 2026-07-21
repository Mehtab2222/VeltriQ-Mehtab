using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VeltriQ.ViewModels.Training
{
    public class TrainingTrainerViewModel
    {
        public int TrainingTrainerId { get; set; }

        public string? TrainerCode { get; set; }

        [Required(ErrorMessage = "Please select trainer type.")]
        public byte TrainerType { get; set; }

        // Internal Trainer
        public int? EmployeeId { get; set; }

        // External Trainer
        [StringLength(200)]
        public string? TrainerName { get; set; }

        [StringLength(20)]
        public string? MobileNo { get; set; }

        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        // Dropdown - Trainer Type
        public List<SelectListItem> TrainerTypes { get; set; } = new()
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Internal"
            },
            new SelectListItem
            {
                Value = "2",
                Text = "External"
            }
        };

        // Dropdown - Employees
        public List<SelectListItem> Employees { get; set; } = new();
    }
}