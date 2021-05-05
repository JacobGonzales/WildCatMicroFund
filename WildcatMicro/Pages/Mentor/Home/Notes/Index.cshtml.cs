using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildcatMicro.DataAccess.Data;
using WildcatMicro.DataAccess.Data.Repository.IRepository;
using WildcatMicro.Models.Models.ViewModels;
using WildcatMicro.Utility;

namespace WildcatMicro.Pages.Mentor.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDBContext _applicationDBContext;


        public IndexModel(IUnitOfWork unitOfWork, ApplicationDBContext applicationDBContext)
        {
            _unitOfWork = unitOfWork;
            _applicationDBContext = applicationDBContext;

        }
        
        [BindProperty]
        public List<MentorAssignmentsNotesVM> mentorAssignmentsNotesVM { get; set; } 
        public List<Models.ApplicationUser> applicationUsers { get; set; }

        public List<IdentityUser> mentors;

        public List<Models.MentorAssignment> ma;

        public int applicant;
        public string name;

        public Models.MentorAssignment assignment;
        
        public IActionResult OnGet(int id)
        {
            applicant = id;
            Models.Application app = _unitOfWork.Application.GetFirstOrDefault(x => x.ApplicantId == applicant);
            string tempId = _unitOfWork.Applicant.GetFirstOrDefault(a => a.ApplicantId == id).ApplicationUserId;
            name = _unitOfWork.ApplicationUser.GetFirstOrDefault(b => b.Id == tempId).FullName;
            if (User.IsInRole(SD.AdministratorRole))
            {
                mentors = _applicationDBContext.Users.Where(p => p.Id == _applicationDBContext.UserRoles.FirstOrDefault(a => a.UserId == p.Id && a.RoleId == "31b1a51e-4cfd-4728-b195-943dbe187246").UserId).ToList();
            }

            if (User.IsInRole(SD.MentorRole))
            {
                assignment = _unitOfWork.MentorAssignment.GetFirstOrDefault(y => y.ApplicationId == app.Id && y.ApplicationUserId == _applicationDBContext.Users.FirstOrDefault(p => p.Email == User.Identity.Name).Id);
            }

            ma = _unitOfWork.MentorAssignment.GetAll(a => a.ApplicationId == app.Id).ToList();
            mentorAssignmentsNotesVM = new List<MentorAssignmentsNotesVM>();
            foreach (var m in ma)
            {
                mentorAssignmentsNotesVM.Add(new MentorAssignmentsNotesVM
                {
                    MentorAssignment = m,
                    MentorNotes = _unitOfWork.MentorNotes.GetAll(b => b.MentorAssignmentId == m.MentorAssignmentId).ToList()
                });
            }


            return Page();
           
        }


        public IActionResult OnPost()
        {
            applicant = Int32.Parse(Request.Form["applicantId"]);
            Models.Application app = _unitOfWork.Application.GetFirstOrDefault(x => x.ApplicantId == applicant);
            bool change = false;

            if (User.IsInRole(SD.AdministratorRole))
            {
                mentors = _applicationDBContext.Users.Where(p => p.Id == _applicationDBContext.UserRoles.FirstOrDefault(a => a.UserId == p.Id && a.RoleId == "31b1a51e-4cfd-4728-b195-943dbe187246").UserId).ToList();
            }

            if (mentors != null)
            {
                foreach (var m in mentors)
                {
                    Models.MentorAssignment ma = _applicationDBContext.MentorAssignment.First(a => a.ApplicationUserId == m.Id && a.ApplicationId == app.Id);

                    if (ma != null)
                    {
                        if (ma.enabled != (Request.Form[m.Id] != "") ? true : false)
                        {
                            ma.enabled = (Request.Form[m.Id] != "") ? true : false;
                            _unitOfWork.MentorAssignment.Update(ma);
                            change = true;
                        }
                    }
                    else
                    {
                        
                        ma = new Models.MentorAssignment();

                        if (Request.Form[m.Id] != "")
                        {
                            ma.enabled = true;
                            ma.ApplicationUserId = m.Id;
                            ma.ApplicationId = app.Id;
                            ma.DateAssigned = DateTime.Today;
                            _unitOfWork.MentorAssignment.Add(ma);
                            change = true;
                        }

                    }

                }

            }
           

            if (Request.Form["newNote"] != "")
            {

                var u = _applicationDBContext.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
                Models.MentorAssignment ma = _unitOfWork.MentorAssignment.GetFirstOrDefault(a => a.ApplicationUserId == u.Id && a.ApplicationId == app.Id);
                if (ma != null)
                {
                    Models.MentorNotes note = new Models.MentorNotes();
                    note.MeetingDate = DateTime.Parse(Request.Form["newDate"]);
                    note.Notes = Request.Form["newNote"];
                    note.MentorAssignmentId = ma.MentorAssignmentId;
                    _unitOfWork.MentorNotes.Add(note);
                    change = true;
                }
                else
                {
                    ma.ApplicationId = app.Id;
                    ma.ApplicationUserId = u.Id;
                    ma.DateAssigned = DateTime.Now;
                    ma.enabled = true;
                    Models.MentorNotes note = new Models.MentorNotes();
                    note.MeetingDate = DateTime.Parse(Request.Form["newDate"]);
                    note.Notes = Request.Form["newNote"];
                    note.MentorAssignmentId = ma.MentorAssignmentId;
                    _unitOfWork.MentorNotes.Add(note);
                    change = true;
                }

                
            }
            

            if(change == true)
            {
                _unitOfWork.Save();
                
            }
           
            return RedirectToPage("/Index", new { id = app.Id });

        }
        
    }
}
