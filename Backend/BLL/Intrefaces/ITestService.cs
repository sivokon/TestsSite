using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface ITestService
    {
        IEnumerable<TestDTO> GetAll();
        TestDTO GetById(int id);
        void Add(TestDTO entity);
        void Update(int testId, TestDTO entity);
        void Delete(int id);

        IEnumerable<TestDTO> GetTestsByCategoryId(int id);
        IEnumerable<TestDTO> GetTestsByTitleKeyWord(string keyWord);
    }
}
