using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data;
using WildcatMicro.DataAccess.Data.Repository;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;


namespace WildcatMicro.Pages.Admin.ReviewApplications
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDBContext _dbContext;

        public IndexModel(IUnitOfWork unitOfWork, ApplicationDBContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }


        public IEnumerable<QuestionResponses> Responses { get; set; }
        public IList<QuestionResponses> ResponsesList { get; set; }
        public IEnumerable<Application> ApplicationList { get; set; }
        public IEnumerable<Statuses> Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public void OnGet()
        {

            Status = _unitOfWork.StatusesRepository.GetAll();
            var Applications = _unitOfWork.Application.GetAll(null, q => q.OrderBy(c => c.Id), "Applicant,Statuses,Applicant.Business,Applicant.ApplicationUser");
            if (string.IsNullOrEmpty(SearchString))
            {
                ApplicationList = Applications;
            }
            else
            {
                ApplicationList = Applications.Where(a => a.Applicant.Business.Name.Contains(SearchString)
                || a.Applicant.ApplicationUserId.Contains(SearchString) || a.Statuses.Status.Contains(SearchString));
            }
        }
    }
}
