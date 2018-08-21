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
    public class CorrectAnswerRepository : BaseRepository<CorrectAnswer>, ICorrectAnswerRepository
    {
        public CorrectAnswerRepository(TestDbContext context) : base(context)
        {
        }

        //IEnumerable<CorrectAnswer> ICorrectAnswerRepository.GetCorrectAnswersByTestId(int id)
        //{
        //    //return this.GetManyByPredicate(corrAnsw => corrAnsw.TestId == id);
        //    return this._context.CorrectAnwers.Where(corrAnsw => corrAnsw.TestId == id).ToList();
        //}

        IEnumerable<CorrectAnswer> ICorrectAnswerRepository.GetCorrectAnswersWithCorrectOptionsByTestId(int id)
        {
            return this.GetManyByPredicate(corrAnsw => corrAnsw.TestId == id, 
                                           corrAnsw => corrAnsw.CorrectAnswerOptions);
        }

    }
}
