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
    public class QuestionCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.QuestionCategorys.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDB = _unitOfWork.QuestionCategorys.GetFirstOrDefault(u => u.QuestionCategoryId == id);

            if (objFromDB == null)
            {
                return Json(new { sucess = false, message = "Error while deleteing" });
            }
            _unitOfWork.QuestionCategorys.Remove(objFromDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
