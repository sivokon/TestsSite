using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class OptionBindingModel
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Too long option. Option can not contain more than {1} characters")]
        public string Body { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Question can not have more then {2} options")]
        public int Index { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }

    public class OptionViewModel
    {
        public int QuestionId { get; set; }
        public string Body { get; set; }
        public int Index { get; set; }
    }
}