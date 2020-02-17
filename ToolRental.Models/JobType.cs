using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRental.Models
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Job Type")]
        public string Name { get; set; }
    }
}
