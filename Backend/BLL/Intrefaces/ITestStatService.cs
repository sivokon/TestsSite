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
        //IEnumerable<TestStat> GetAll();
        TestStatDTO GetById(int id);
        //void Add(TestStatDTO entity);
        //void Update(TestStatDTO entity);
        //void Delete(int id);

        void StartTest(TestStatDTO entity);
        void SaveCompletedTest(TestStatDTO entity);

        IEnumerable<TestStatDTO> GetTestStatisticsByUserId(string id);
        IEnumerable<TestStatDTO> GetTestStatisticsWithRelatedTestsByUserId(string id);
        TestStatDTO GetNotFinishedTestByUserId(string id);
    }
}
