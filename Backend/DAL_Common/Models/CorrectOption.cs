using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class CorrectOption : Entity
    {
        public int OptionId { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
