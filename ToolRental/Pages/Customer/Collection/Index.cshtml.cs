using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;
using ToolRental.Models.ViewModels;

namespace ToolRental.Pages.Customer.Collection
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        
        public RentalItemCollectionVM RentalItemCollection;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            
            RentalItemCollection.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstORDefault(i => i.Id == claim.Value);
        }
    }
}