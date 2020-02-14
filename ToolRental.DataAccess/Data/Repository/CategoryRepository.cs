﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
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

        public void update(Category category)
        {
            var objFromDB = _db.Category.FirstOrDefault(i => i.Id == category.Id);
            objFromDB.Name = category.Name;
            objFromDB.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }

        
    }
}
