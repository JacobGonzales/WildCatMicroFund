using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildcatMicro.DataAccess.Data.Repository.IRepository;

namespace WildcatMicro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MentorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Models.Applicant> ApplicantList { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            ApplicantList = _unitOfWork.Applicant.GetAll();

            return Json(new
            {
                data = ApplicantList
            });
        }
    }
}
