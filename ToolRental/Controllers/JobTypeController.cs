using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobTypeController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.JobType.GetAll() });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.JobType.GetFirstORDefault(u => u.Id == id);
            if(objFromDb == null)
            {
                // Bad Id 
                return Json(new { success = false, message = "Error while dDeleting" });
            }
            _unitOfWork.JobType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}