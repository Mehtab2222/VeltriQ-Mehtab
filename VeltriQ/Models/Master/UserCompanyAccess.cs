namespace VeltriQ.Models.Master
{
    public class UserCompanyAccess
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CompanyId { get; set; }

        public bool IsDefault { get; set; }
    }
}