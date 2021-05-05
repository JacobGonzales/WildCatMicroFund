using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WildcatMicro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeQuestionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JudgeQuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.JudgeQuestions.GetAll(null, null, "Questions") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDB = _unitOfWork.JudgeQuestions.GetFirstOrDefault(u => u.JudgeQuestionsId == id);

            if (objFromDB == null)
            {
                return Json(new { sucess = false, message = "Error while deleteing" });
            }
            _unitOfWork.JudgeQuestions.Remove(objFromDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
