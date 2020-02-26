using System;
using System.Collections.Generic;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) :base(db)
        {
            _db = db; 
        }
    }
}
