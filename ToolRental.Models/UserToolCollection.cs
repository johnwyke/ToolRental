using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToolRental.Models
{
    public class UserToolCollection
    {
        public UserToolCollection()
        {
            Count = 1;
        }

        public int Id { get; set; }
        public int RentalItemId { get; set; }

        [Range(1,100, ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("RentalItemId")]
        public virtual RentalItem RentalItem { get; set; }



        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
