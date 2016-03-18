using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class Product : BaseEntity
    {
        [Required, StringLength(255, MinimumLength = STD_MIN_LENGTH)]
        public string Title { get; set; }

        [Required, DataType(DataType.MultilineText), MinLength(STD_MIN_LENGTH)]
        public string Description { get; set; }

        #region Costs
        [Display(Name = "License cost amount")]
        public decimal LicenseCostAmount { get; set; }
        [Display(Name = "Implementation cost amount")]
        public decimal ImplementationCostAmount { get; set; }
        [Display(Name = "Maintenance cost amount")]
        public decimal MaintenanceCostAmount { get; set; }
        [Display(Name = "Service delivery cost amount")]
        public decimal ServiceDeliveryCostAmount { get; set; }
        #endregion

        public ProductType? Type { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }

    public enum ProductType
    {
        This = 1,
        Other = 2
    }
}