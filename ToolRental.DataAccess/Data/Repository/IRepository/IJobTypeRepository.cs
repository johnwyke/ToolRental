using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IJobTypeRepository : IRepository<JobType>
    {
        IEnumerable<SelectListItem> GetJobTypeforDropDown();

        void Update(JobType jobType);
    }
}
