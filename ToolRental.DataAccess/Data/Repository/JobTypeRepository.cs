using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository
{
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public JobTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetJobTypeforDropDown()
        {
            return _db.JobType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(JobType jobType)
        {
            var objFromDb = _db.JobType.FirstOrDefault(i => i.Id == jobType.Id);
            objFromDb.Name = jobType.Name;
            _db.SaveChanges();
        }
    }
}
