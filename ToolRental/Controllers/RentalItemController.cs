using System;
using System.Collections.Generic;
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
            return Json(new { data = _unitOfWork.RentalItem.GetAll(null, null, "Categroy,JobType") });
        }
    }
}