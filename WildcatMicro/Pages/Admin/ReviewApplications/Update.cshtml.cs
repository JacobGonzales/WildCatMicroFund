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
    public class UpdateModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public IEnumerable<Statuses> Status { get; set; }
        public int CurrentStatusId { get; set; }
        public void OnGet(int id)
        {
            Status = _unitOfWork.StatusesRepository.GetAll();  
            CurrentStatusId = _unitOfWork.Application.Get(id).StatusId;
            }

        }
    }
