using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class EntryPointGroup : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<EntryPoint> EntryPoints { get; set; }
    }
}