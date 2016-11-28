using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Models.Categories
{
    public class CategoriesModel
    {
        [HiddenInput(DisplayValue = false)]

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
    }
}