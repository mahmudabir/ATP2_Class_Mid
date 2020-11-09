using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_with_Repository_Pattern.Models
{
    public class ProductMetaData
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name can not be empty."), StringLength(30), DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Range(0, 100000)]
        public double Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}