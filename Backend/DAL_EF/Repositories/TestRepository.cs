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
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(TestDbContext context) : base(context)
        {
        }

        IEnumerable<Test> ITestRepository.GetTestsByCategoryId(int id)
        {
            return this.GetManyByPredicate(test => test.CategoryId == id);
        }

    }
}
