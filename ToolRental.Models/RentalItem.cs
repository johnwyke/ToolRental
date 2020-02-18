using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToolRental.Models
{
    public class RentalItem
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Rental Tool")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater then $1")]
        public double Price { get; set; }

        /// <summary>
        ///Below is how you link the tables to togther. This is critial to know!!
        /// </summary>
        [Display(Name = "Tool Category")]
        public int ToolCategoryId { get; set; }
        [ForeignKey("ToolCategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Job Type")]
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        public virtual JobType JobType { get; set; }
    }
}
