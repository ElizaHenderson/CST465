using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models.MidTerm
{
    public class TrueFalseQuestion : TestQuestion
    {
        [Required]
        [RegularExpression("True|False")]
        public override string Answer { get; set; }
    }
}