using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WildcatMicro.Utility;

namespace WildcatMicro.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.IsInRole(SD.AdministratorRole))
            {
                return RedirectToPage("/Admin/ReviewApplications/Index");
            }
            if (User.IsInRole(SD.ApplicantRole))
            {
                return RedirectToPage("/Applicant/Home/Homepage");
            }
            if (User.IsInRole(SD.JudgeRole))
            {
                return RedirectToPage("/Admin/ReviewApplications/Index");
            }
            if (User.IsInRole(SD.MentorRole))
            {
                return RedirectToPage("/Admin/ReviewApplications/Index");
            }
            else
            {
                return RedirectToPage();
            }

        }
    }
}
