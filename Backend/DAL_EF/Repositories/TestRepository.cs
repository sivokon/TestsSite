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
            //return _context.Tests.Where(test => test.CategoryId == id).ToList();
            return this.GetManyByPredicate(test => test.CategoryId == id);
        }



        //IEnumerable<Test> ITestRepository.GetTestsByCategory()
        //{
        //    IQueryable<Test> testsByCategory = _context.Tests.Join(_context.TestCategories,
        //                                                            test => test.CategoryId,
        //                                                            cat => cat.Id,
        //                                                            (test, category) => new Test()
        //                                                            {
        //                                                                Title = test.Title,
        //                                                                Descr = test.Descr,
        //                                                                CreationDate = test.CreationDate,
        //                                                                DurationMin = test.DurationMin,
        //                                                                CategoryId = test.CategoryId,
        //                                                                Category = test.Category,
        //                                                                Questions = test.Questions,
        //                                                                TestStatistics = test.TestStatistics
        //                                                            });
        //    return testsByCategory.ToList();
        //}

    }
}
