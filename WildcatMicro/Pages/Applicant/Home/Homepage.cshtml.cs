using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;
using WildcatMicro.Models.Models.ViewModels;

namespace WildcatMicro.Pages.Applicant.Home
{
    [Authorize]
    public class HomepageModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUser ApplicationUser;
        public HomepageModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(a => a.Email == User.Identity.Name);
        }
    }
}
