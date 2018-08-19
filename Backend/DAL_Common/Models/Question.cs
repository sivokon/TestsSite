using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class Question : Entity
    {
        public string Body { get; set; }
        public int Index { get; set; }

        public int TestId { get; set; }
        public virtual Test Test { get; set; }

        public ICollection<Option> Options { get; set; }
        public ICollection<CorrectOption> CorrectOptions { get; set; }
    }
}
