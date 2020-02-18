using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using ToolRental.Models;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IRentalItemRepository : IRepository<RentalItem>
    {
        void Update(RentalItem rentalItem);
        
    }
}
