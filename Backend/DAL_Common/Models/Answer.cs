using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class Answer : Entity
    {
        public int QuestionId { get; set; }
        public int PointValue { get; set; }

        public int TestStatId { get; set; }
        public virtual TestStat TestStatistic { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
