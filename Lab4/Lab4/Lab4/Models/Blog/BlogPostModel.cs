using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab4.Models.Blog
{
    public class BlogPostModel
    {
        [HiddenInput(DisplayValue = false)]

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("My Cool Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }
        public object ModelState { get; internal set; }
    }
}