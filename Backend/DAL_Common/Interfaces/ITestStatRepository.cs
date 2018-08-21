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
        IEnumerable<TestStat> GetTestStatisticsWithRelatedTestsByUserId(string id);
        IEnumerable<TestStat> GetTestStatisticsWithAnswersByTestId(int id);
        void DeleteNotFinishedTestStatisticsByUserId(string id);
        TestStat GetNotFinishedTestByUserId(string id);
        void UpdateRange(IEnumerable<TestStat> statsToUpdate);
    }
}
