using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRental.Models.ViewModels
{
    public class RentalItemCollectionVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public List<RentalItem> RentalItemList { get; set; }
    }
}
