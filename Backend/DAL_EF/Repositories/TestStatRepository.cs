using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
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

        IEnumerable<TestStat> ITestStatRepository.GetTestStatisticsWithRelatedTestsByUserId(string id)
        {
            return this.GetManyByPredicate(testStat => testStat.UserId == id, 
                                           testStat => testStat.Test);
        }

        void ITestStatRepository.DeleteNotFinishedTestStatisticsByUserId(string id)
        {
            IEnumerable<TestStat> testStatsOfUser = this._dbSet.Where(testStat => testStat.UserId == id && 
                                                                      testStat.EndTime == SqlDateTime.MinValue.Value);
            this._dbSet.RemoveRange(testStatsOfUser);
        }

        TestStat ITestStatRepository.GetNotFinishedTestByUserId(string id)
        {
            return this.GetSingleByPredicate(testStat => testStat.UserId == id && 
                                             testStat.EndTime == SqlDateTime.MinValue.Value);
        }

        public override void Add(TestStat entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.StartTime = this.CheckAndAdaptToSqlDateTime(entity.StartTime);
            entity.EndTime = this.CheckAndAdaptToSqlDateTime(entity.EndTime);

            this._dbSet.Add(entity);
        }

        private DateTime CheckAndAdaptToSqlDateTime(DateTime dateTime)
        {
            if (dateTime < SqlDateTime.MinValue.Value)
            {
                dateTime = SqlDateTime.MinValue.Value;
            }

            if (dateTime > SqlDateTime.MaxValue.Value)
            {
                dateTime = SqlDateTime.MaxValue.Value;
            }

            return dateTime;
        }

    }
}
