using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository
{
    public class RentalItemRepository : Repository<RentalItem>, IRentalItemRepository
    {
        private readonly ApplicationDbContext _db;
        public RentalItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }


        public void Update(RentalItem rentalItem)
        {
            var objFromDB = _db.RentalItem.FirstOrDefault(i => i.Id == rentalItem.Id);
            objFromDB.Name = rentalItem.Name;
            objFromDB.ToolCategoryId = rentalItem.ToolCategoryId;
            objFromDB.Price = rentalItem.Price;
            objFromDB.Description = rentalItem.Description;
            objFromDB.JobType = rentalItem.JobType;

            if (objFromDB.Image != null)
            {
                objFromDB.Image = rentalItem.Image;
            }

            _db.SaveChanges();
        }

        
    }
}
