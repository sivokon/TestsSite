using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO : EntityDTO
    {
        public string Body { get; set; }
        public int Index { get; set; }
        public int TestId { get; set; }

        public List<OptionDTO> Options { get; set; }

        public List<CorrectOptionDTO> CorrectOptions { get; set; }
    }
}
