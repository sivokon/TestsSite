﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;

namespace WebAPI.Models
{
    public class TestStatViewModel
    {
        public int TestId { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}