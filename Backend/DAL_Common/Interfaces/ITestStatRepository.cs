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
        IEnumerable<TestStat> GetTestStatisticsByUserId(string id);
        IEnumerable<TestStat> GetTestStatisticsWithRelatedTestsByUserId(string id);
        void DeleteNotFinishedTestStatisticsByUserId(string id);
        TestStat GetNotFinishedTestByUserId(string id);
    }
}
