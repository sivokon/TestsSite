using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AnswerViewModel
    {
        public int QuestionId { get; set; }
        public int OptionIndex { get; set; }
    }
}