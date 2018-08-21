using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestDTO : EntityDTO
    {
        public string Title { get; set; }
        public string Descr { get; set; }
        public DateTime CreationDate { get; set; }
        public int DurationMin { get; set; }
        public int CategoryId { get; set; }

        public List<QuestionDTO> Questions { get; set; }
    }
}
