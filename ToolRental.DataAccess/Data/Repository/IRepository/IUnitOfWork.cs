﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;}

        void Save();
    }
}
