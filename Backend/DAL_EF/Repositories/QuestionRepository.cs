using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using DAL_Common.Interfaces;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(TestDbContext context) : base(context)
        {
        }

        Question IQuestionRepository.GetQuestionByIndexAndTestId(int index, int testId)
        {
            return this.GetSingleByPredicate(question => question.TestId == testId && question.Index == index);
        }

        IEnumerable<Question> IQuestionRepository.GetQuestionsByTestId(int id)
        {
            //return this.GetManyByPredicate(question => question.TestId == id);
            return this._context.Questions.Include("Options").Where(question => question.TestId == id).ToList();
        }

    }
}
