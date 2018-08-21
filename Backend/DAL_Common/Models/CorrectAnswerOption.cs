using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class CorrectAnswerOption : Entity
    {
        public int OptionId { get; set; }

        public int CorrectAnswerId { get; set; }
        public CorrectAnswer CorrectAnswer { get; set; }
    }
}
