using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestStatDTO : EntityDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Result { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
