using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRental.Models.ViewModels
{
    public class RentalItemVM
    {
        public RentalItem RentalItem { get; set; }
        public IEnumerable<SelectListItem> ToolCategoryList { get; set; }

        public IEnumerable<SelectListItem> JobTypeList { get; set; }
    }
}
