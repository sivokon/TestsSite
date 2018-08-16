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
    public class TestStatRepository : BaseRepository<TestStat>, ITestStatRepository
    {
        public TestStatRepository(TestDbContext context) : base(context)
        {
        }

        IEnumerable<TestStat> ITestStatRepository.GetTestStatisticsByUserId(string id)
        {
            return this.GetManyByPredicate(testStat => testStat.UserId == id);
        }
    }
}
