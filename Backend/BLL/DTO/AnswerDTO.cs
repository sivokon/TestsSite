﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AnswerDTO : EntityDTO
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int TestStatId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
