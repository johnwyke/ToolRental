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
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitofWork;

        public UserController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitofWork.ApplicationUser.GetAll() });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _unitofWork.ApplicationUser.GetFirstORDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error While Locking / Unlocking" });
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                // User is currently locked out so unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _unitofWork.Save();

            return Json(new { success = true, message = "Lock / Unlock Successful" });
        }

    }
}