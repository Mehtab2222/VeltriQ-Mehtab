using System.ComponentModel.DataAnnotations;

namespace VeltriQ.Models.Master
{
    public class MasterCompany
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string DatabaseName { get; set; }

        public string? ServerName { get; set; }

        public string? DatabaseUserName { get; set; }

        public string? DatabasePassword { get; set; }

        public string? ConnectionString { get; set; }

        public bool IsActive { get; set; }
    }
}