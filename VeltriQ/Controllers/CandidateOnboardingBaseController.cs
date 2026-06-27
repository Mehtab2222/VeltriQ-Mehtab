using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VeltriQ.Data;

namespace VeltriQ.Controllers
{
    public class CandidateOnboardingBaseController : Controller
    {
        protected readonly TenantDbContext _context;

        public CandidateOnboardingBaseController(TenantDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewBag.EmployeeOnboardingId =
                HttpContext.Session.GetInt32("EmployeeOnboardingId");

            ViewBag.OnboardingCandidateId =
                HttpContext.Session.GetInt32("OnboardingCandidateId");

            ViewBag.InvitationId =
                HttpContext.Session.GetInt32("OnboardingCandidateInvitationId");

            ViewBag.CandidateName =
                HttpContext.Session.GetString("CandidateName");
        }
    }
}