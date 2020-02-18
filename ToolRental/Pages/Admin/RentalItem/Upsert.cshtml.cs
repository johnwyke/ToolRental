using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models.ViewModels;

namespace ToolRental.Pages.Admin.RentalItem
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvrionment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvrionment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvrionment = hostingEnvrionment;
        }

        [BindProperty]
        public RentalItemVM RentalItemObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            RentalItemObj = new RentalItemVM()
            {
                ToolCategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                JobTypeList = _unitOfWork.JobType.GetJobTypeforDropDown(),
                RentalItem = new Models.RentalItem()
            };

            if (id != null)
            { // edit
                RentalItemObj.RentalItem = _unitOfWork.RentalItem.GetFirstORDefault(u => u.Id == id);
                if (RentalItemObj == null)
                {
                    // bad Id 
                    return NotFound();

                }
            }
            return Page();

        }

        public IActionResult OnPost()
        {
            // Find the path to wwwroot 
            string webRootPath = _hostingEnvrionment.WebRootPath;
            // Grab the File(s)
            var files = HttpContext.Request.Form.Files;




            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (RentalItemObj.RentalItem.Id == 0) // This is a new Rental Item
            {
                //Rename the file user submits
                string fileName = Guid.NewGuid().ToString();
                // upload to path 
                var uploads = Path.Combine(webRootPath, @"images\RentalItems");
                //perserve our extension
                var extension = Path.GetExtension(files[0].FileName);

                // Append file name 
                using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))

                {
                    files[0].CopyTo(filestream);

                }

                RentalItemObj.RentalItem.Image = @"\images\RentalItems\" + fileName + extension;
                _unitOfWork.RentalItem.Add(RentalItemObj.RentalItem);
            }
            else
            {
                // this is an Edit
                //**************************

                var objFromDb = _unitOfWork.RentalItem.Get(RentalItemObj.RentalItem.Id);

                // were there any files submitted with the post? 
                if (files.Count > 0)
                {
                    // Assume the submitted files
                    //Rename the file user submits
                    string fileName = Guid.NewGuid().ToString();
                    // upload to path 
                    var uploads = Path.Combine(webRootPath, @"images\RentalItems");
                    //perserve our extension
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var filestream = new FileStream(Path.Combine(uploads, fileName, extension), FileMode.Create))

                    {
                        files[0].CopyTo(filestream);

                    }

                    RentalItemObj.RentalItem.Image = @"\images\RentalItems\" + fileName + extension;

                }
                else
                {
                    RentalItemObj.RentalItem.Image = objFromDb.Image;
                }


                _unitOfWork.RentalItem.Update(RentalItemObj.RentalItem);
            }
            // It is all Local Before this line
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}