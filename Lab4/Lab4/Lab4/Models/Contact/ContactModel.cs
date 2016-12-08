using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models.Contact
{
    public class ContactModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public object ModelState { get; internal set; }
    }
}