using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class StartTestBindingModel
    {
        [Required]
        public int TestId { get; set; }
    }

    public class FinishTestBindingModel
    {
        [Required]
        public int TestId { get; set; }

        [Required]
        public List<AnswerDTO> Answers { get; set; }
    }
}