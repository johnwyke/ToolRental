using System;
using System.Collections.Generic;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            JobType = new JobTypeRepository(_db);
            RentalItem = new RentalItemRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);

        }
        public ICategoryRepository Category { get; private set; }
        public IJobTypeRepository JobType { get; private set; }
        public IRentalItemRepository RentalItem { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        

        public void Dispose()
        {
         //   throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
