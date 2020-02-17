using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Models.Category CategoryObj { get; set; }
        public UpsertModel(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public IActionResult OnGet(int? id)
        {
            CategoryObj = new Models.Category();
            if(id != null)
            {
                // There it is an edit 
                CategoryObj = _unitOfWork.Category.GetFirstORDefault(u => u.Id == id);
                if(CategoryObj == null)
                {
                    // Cant Find Obj 
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

            if(CategoryObj.Id == 0)
            {
                // THis is new 
                _unitOfWork.Category.Add(CategoryObj);
            }
            else
            {
                _unitOfWork.Category.update(CategoryObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}