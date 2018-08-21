using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class QuestionBindingModel
    {
        [Required]
        public int TestId { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "Too long question. Question can not contain more than {1} characters")]
        public string Body { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Test can not have more then {2} questions")]
        public int Index { get; set; }

        [Required]
        public List<NewOptionBindingModel> Options { get; set; }
    }

    public class QuestionViewModel
    {
        public int TestId { get; set; }
        public string Body { get; set; }
        public int Index { get; set; }
        public List<OptionViewModel> Options { get; set; }
    }

}