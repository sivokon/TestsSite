using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface ITestStatRepository : IRepository<TestStat>
    {
        IEnumerable<TestStat> GetTestStatisticsWithRelatedTestsByUserId(int id);

        IEnumerable<TestStat> GetTestStatisticsWithAnswersByTestId(int id);

        void DeleteNotFinishedTestStatisticsByUserId(int id);

        TestStat GetNotFinishedTestByUserId(int id);

        void UpdateRange(IEnumerable<TestStat> statsToUpdate);
    }
}
