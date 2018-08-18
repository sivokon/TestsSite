using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface ITestStatService
    {
        //IEnumerable<TestStat> GetAll();
        TestStatDTO GetById(int id);
        void Add(TestStatDTO entity);
        void Update(TestStatDTO entity);
        //void Delete(int id);

        IEnumerable<TestStatDTO> GetTestStatisticsByUserId(string id);
        IEnumerable<TestStatDTO> GetTestStatisticsWithRelatedTestsByUserId(string id);
    }
}
