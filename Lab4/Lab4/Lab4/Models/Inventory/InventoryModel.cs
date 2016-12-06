using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Models
{
    public class InventoryModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string ProductDescription { get; set; }

        public HttpPostedFileWrapper ProductImage { get; set; }

        public SelectList Categories { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}