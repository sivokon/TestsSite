using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;
using BLL.Services;

namespace BLL.Intrefaces
{
    public interface ITestStatService
    {
        void StartTest(TestStatDTO entity);
        void SaveCompletedTest(TestStatDTO entity);

        IEnumerable<TestStatDTO> GetTestStatisticsWithRelatedTestsByUserId(string id);
    }
}
