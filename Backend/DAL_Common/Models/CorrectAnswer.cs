using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class CorrectAnswer : Entity
    {
        public int TestId { get; set; }
        public virtual Test Test { get; set; }

        public int QuestionId { get; set; }
        public int MaxPointValue { get; set; }

        public virtual ICollection<CorrectAnswerOption> CorrectAnswerOptions { get; set; }
        //public virtual ICollection<Option> Options { get; set; }
    }
}
