using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OptionDTO : EntityDTO
    {
        public string Body { get; set; }
        public int Index { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
