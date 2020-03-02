using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;
using ToolRental.Utility;

namespace ToolRental.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;


        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        [BindProperty]
        public UserToolCollection  UserToolCollection { get; set; }
        public void OnGet(int id)
        {
            UserToolCollection = new UserToolCollection()
            {
                RentalItem = _unitOfWork.RentalItem.GetFirstORDefault(includeProperties: "Category,JobType", filter: c => c.Id == id),
                RentalItemId = id
                
            };
        }
        public IActionResult OnPost()
        {
            if (!User.IsInRole(SD.CustomerRole) && !User.IsInRole(SD.ManagerRole))
            {
                // User is not Logged In as Customer then Direct to Login Page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                    UserToolCollection.ApplicationUserId = claim.Value;

                    UserToolCollection cartFromDB = _unitOfWork.UserToolCollection.GetFirstORDefault(u => u.ApplicationUserId == UserToolCollection.ApplicationUserId &&
                    u.RentalItemId == UserToolCollection.RentalItemId);


                    // Does the shopping cart exists (Item list) in the DB
                    if (cartFromDB == null)
                    {
                        _unitOfWork.UserToolCollection.Add(UserToolCollection);
                    }
                    _unitOfWork.Save();

                    var count = _unitOfWork.UserToolCollection.GetAll(c => c.ApplicationUserId == UserToolCollection.ApplicationUserId).ToList().Count;

                    HttpContext.Session.SetInt32(SD.ShoppingCart, count);
                    return RedirectToPage("Index");
                }
                else
                {
                    // Adding a New Item 
                    UserToolCollection.RentalItem= _unitOfWork.RentalItem.GetFirstORDefault(includeProperties: "Category,JobType", filter: c => c.Id == UserToolCollection.RentalItemId);
                    return Page();
                }
            }
        }
    }
}