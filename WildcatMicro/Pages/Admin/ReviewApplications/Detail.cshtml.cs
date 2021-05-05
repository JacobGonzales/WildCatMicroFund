using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro
{
    public class DetailModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public DetailModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public IEnumerable<QuestionResponses> ResponsesObj { get; set; }

        public string businessName { get; set; }
        public void OnGet(int id, string businessName)
        {
            this.businessName = businessName; // generatig business Name

            ResponsesObj = _unitOfWork.Responses.GetAll(includeProperties: "Questions,Application,Application.Applicant",
               filter: c => c.ApplicationId == id);
            if (ResponsesObj.Count() > 0)
            {

                //var business = _unitOfWork.Get(ResponsesObj.First().Application.Applicant.BusinessId);
              //  businessName = business.Name;
            }

        }
    }
}