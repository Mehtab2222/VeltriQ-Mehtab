using VeltriQ.Models.Core;

namespace VeltriQ.Models.HR
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? OfficialEmail { get; set; }

        public string? PhoneNumber { get; set; }

        public int BranchId { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public int? ReportingManagerId { get; set; }

        public DateTime? JoiningDate { get; set; }

        public string? EmploymentType { get; set; }

        public string? EmployeeStatus { get; set; }

        public string? ProfilePhotoPath { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Branch? Branch { get; set; }

        public virtual Department? Department { get; set; }

        public virtual Designation? Designation { get; set; }
        public int? DivisionId { get; set; }

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? MaritalStatus { get; set; }

        public string? BloodGroup { get; set; }

        public int? NationalityId { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public string? EmploymentStatus { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        public virtual Division? Division { get; set; }

        public virtual Nationality? Nationality { get; set; }

        public virtual Country? Country { get; set; }

        public virtual City? City { get; set; }
        public string? CurrentAddress { get; set; }

        public string? PermanentAddress { get; set; }
        public int? CompanyId { get; set; }

        public Company? Company { get; set; }
        public string? Pincode { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public bool IsSuspended { get; set; }
        public virtual ICollection<EmployeeAddress> Addresses { get; set; }
    = new List<EmployeeAddress>();

        public virtual ICollection<EmployeeEmergencyContact> EmergencyContacts { get; set; }
            = new List<EmployeeEmergencyContact>();

        public virtual ICollection<EmployeeDependent> Dependents { get; set; }
            = new List<EmployeeDependent>();

        public virtual ICollection<EmployeeQualification> Qualifications { get; set; }
            = new List<EmployeeQualification>();
    }
}