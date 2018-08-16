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
    public class OptionRepository : BaseRepository<Option>, IOptionRepository
    {
        public OptionRepository(TestDbContext context) : base(context)
        {
        }

        IEnumerable<Option> IOptionRepository.GetOptionsByQuestionId(int id)
        {
            return this.GetManyByPredicate(option => option.QuestionId == id);
        }
    }
}
