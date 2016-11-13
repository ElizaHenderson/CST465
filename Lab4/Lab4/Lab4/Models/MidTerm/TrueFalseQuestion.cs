using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models.MidTerm
{
    public class TrueFalseQuestion : TestQuestion
    {
        [Required(ErrorMessage = "You didn't put True or False...")]
        [RegularExpression("True|False")]
        public override string Answer { get; set; }
        public object ModelState { get; internal set; }

    }
}