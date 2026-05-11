using Microsoft.AspNetCore.Identity;

namespace VeltriQ.Models.Core
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public bool IsActive { get; set; }
    }
}