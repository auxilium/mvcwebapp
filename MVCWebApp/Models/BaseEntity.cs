using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace MVCWebApp.Models
{
    public class BaseEntity
    {
        // Constants
        public const int STD_MIN_LENGTH = 3;

        public int ID { get; set; }

//        [Display(Name = "Some date")]
  //      [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Modified { get; set; }
    }

}