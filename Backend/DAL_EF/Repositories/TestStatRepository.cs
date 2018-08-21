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

        IEnumerable<TestStat> ITestStatRepository.GetTestStatisticsWithRelatedTestsByUserId(string id)
        {
            return this.GetManyByPredicate(testStat => testStat.UserId == id, 
                                           testStat => testStat.Test);
        }

        IEnumerable<TestStat> ITestStatRepository.GetTestStatisticsWithAnswersByTestId(int id)
        {
            return this.GetManyByPredicate(testStat => testStat.TestId == id,
                                           testStat => testStat.Answers);
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

        void ITestStatRepository.UpdateRange(IEnumerable<TestStat> statsToUpdate)
        {
            if (statsToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (TestStat testStat in statsToUpdate)
            {
                TestStat statToUpdate = _dbSet.Find(testStat.Id);

                if (statToUpdate == null)
                {
                    throw new ArgumentException();
                }

                _context.Entry(statToUpdate).CurrentValues.SetValues(testStat);
            }            
        }

        public override void Add(TestStat entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.StartTime = this.AdaptToSqlDateTime(entity.StartTime);
            entity.EndTime = this.AdaptToSqlDateTime(entity.EndTime);

            this._dbSet.Add(entity);
        }

        private DateTime AdaptToSqlDateTime(DateTime dateTime)
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
