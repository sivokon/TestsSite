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
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(TestDbContext context) : base(context)
        {
        }

        IEnumerable<Answer> IAnswerRepository.GetAnswersByTestStatisticId(int id)
        {
            return this.GetManyByPredicate(answer => answer.TestStatId == id);
        }
    }
}
