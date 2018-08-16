using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class Test : Entity
    {
        public string Title { get; set; }
        public string Descr { get; set; }
        public DateTime CreationDate { get; set; }
        public int DurationMin { get; set; }

        public int CategoryId { get; set; }
        public virtual TestCategory Category { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<TestStat> TestStatistics { get; set; }
    }
}
