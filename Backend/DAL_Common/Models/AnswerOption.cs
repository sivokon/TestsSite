using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class AnswerOption : Entity
    {
        public int OptionId { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
