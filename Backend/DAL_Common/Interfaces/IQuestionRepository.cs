using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionsByTestId(int id);

        Question GetQuestionByIndexAndTestId(int index, int testId);

        IEnumerable<Question> GetQuestionsWithOptionsByTestId(int id);
    }
}
