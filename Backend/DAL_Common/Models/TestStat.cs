using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class TestStat : Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Result { get; set; }

        public int TestId { get; set; }
        public virtual Test Test { get; set; }

        public string UserId { get; set; }
        //public virtual User User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
