using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models.MidTerm
{

    public class ShortAnswerQuestion : TestQuestion
    {
        [Required]
        [MaxLength(100, ErrorMessage ="Answer too long. Limit to 100 characters please")]
        public override string Answer { get; set; }
        public object ModelState { get; internal set; }

    }
}