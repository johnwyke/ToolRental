using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RentalItemController(IUnitOfWork unitofwork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitofwork;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.RentalItem.GetAll(null, null, "Category,JobType") });
        }

        [HttpDelete("ID")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWork.RentalItem.GetFirstORDefault(c => c.Id == id);
                if(objFromDb == null)
                {
                    return Json(new { success = false, message = " Error while Deleting" });
                }
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _unitOfWork.RentalItem.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete successful" });
            }catch(Exception ex)
            {
               
                return Json(new { success = false, message = "Error While Deleting obj" });
            }

        }
    }
}