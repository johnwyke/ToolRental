using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository
{
    public class UserToolCollectionRepository : Repository<UserToolCollection>, IUserToolCollectionRepository
    {
        private readonly ApplicationDbContext _db;
        public UserToolCollectionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem(){ 
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetUserToolCollectionListForDropDown()
        {
            return _db.UserToolCollections.Select(i => new SelectListItem()
            {
                Text = i.RentalItem.Name,
                Value = i.RentalItemId.ToString()
            });
        }

        public void update(UserToolCollection userToolCollection)
        {
            var objFromDB = _db.UserToolCollections.FirstOrDefault(i => i.Id == userToolCollection.Id);

            objFromDB.RentalItemId = userToolCollection.RentalItemId;
            objFromDB.ApplicationUserId = userToolCollection.ApplicationUserId;
            _db.Update(userToolCollection);
        }

        
    }
}
