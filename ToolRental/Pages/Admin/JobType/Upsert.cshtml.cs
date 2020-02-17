using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental.Pages.Admin.JobType
{
    public class UpsertModel : PageModel
    {
        public IUnitOfWork _unitOfWork;

        [BindProperty]
        public Models.JobType JobTypeObj { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 

        }
        public IActionResult OnGet(int? id)
        {
            JobTypeObj = new Models.JobType();
            if (id != null)
            {
                JobTypeObj = _unitOfWork.JobType.GetFirstORDefault(u => u.Id == id);
                if(JobTypeObj == null)
                {
                    // Cant be found 
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(JobTypeObj.Id == 0)
            {
                // Its new
                _unitOfWork.JobType.Add(JobTypeObj);
            }
            else
            {
                _unitOfWork.JobType.Update(JobTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}