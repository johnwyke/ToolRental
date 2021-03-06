﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IUserToolCollectionRepository : IRepository<UserToolCollection>
    {
        IEnumerable<SelectListItem> GetUserToolCollectionListForDropDown();


        void update(UserToolCollection userToolCollection);
        
    }
}
