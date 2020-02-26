using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Category> CategoryList;
        public IEnumerable<RentalItem> RentalItemList; 

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        public void OnGet()
        {
            RentalItemList = _unitOfWork.RentalItem.GetAll(null, null, "Category,JobType");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);

        }
    }
}