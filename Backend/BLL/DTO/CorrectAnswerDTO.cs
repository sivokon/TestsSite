using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CorrectAnswerDTO
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int MaxPointValue { get; set; }

        public List<CorrectAnswerOptionDTO> CorrectAnswerOptions { get; set; }
    }
}
