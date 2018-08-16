using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface ITestCategoryService
    {
        IEnumerable<TestCategoryDTO> GetAll();
        TestCategoryDTO GetById(int id);
        //void Add(TestCategory entity);
        void Update(TestCategoryDTO entity);
        //void Delete(int id);
    }
}
