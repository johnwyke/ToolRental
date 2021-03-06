﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;}
        IJobTypeRepository JobType { get; }
        IRentalItemRepository RentalItem { get; }
        IApplicationUserRepository ApplicationUser { get; }

        IUserToolCollectionRepository UserToolCollection { get; }

        void Save();
    }
}
