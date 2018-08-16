using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class Option : Entity
    {
        public string Body { get; set; }
        public int Index { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        //public virtual ICollection<Answer> Answers { get; set; }
    }
}
