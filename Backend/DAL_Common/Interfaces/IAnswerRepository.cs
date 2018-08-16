using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        IEnumerable<Answer> GetAnswersByTestStatisticId(int id);
    }
}
