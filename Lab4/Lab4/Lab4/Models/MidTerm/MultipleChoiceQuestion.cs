using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models.MidTerm
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required(ErrorMessage = "Please fill this out")]
        public override string Answer{ get; set; }

        public List<string> choices { get; set; }
        public object ModelState { get; internal set; }

    }
}