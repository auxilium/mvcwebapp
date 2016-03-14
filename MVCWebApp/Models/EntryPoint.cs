using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace MVCWebApp.Models
{
    public class EntryPoint : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual EntryPointGroup group { get; set; }
    }
}