using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models;

namespace WildcatMicro.Pages.Judge.PitchMeeting.PitchHistory
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Pitch> PitchList { get; set; }

        public Models.Applicant ApplicantObj { get; set; }

        public void OnGet(int? id)
        {
            ApplicantObj = _unitOfWork.Applicant.GetFirstOrDefault(a => a.ApplicantId == id, "Business");

            var Pitches = _unitOfWork.Pitch.GetAll(null, p => p.OrderBy(q => q.PitchDate), "Application").Where(p => p.Application.ApplicantId == id);
            PitchList = Pitches;
        }
    }
}
