using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface ITestRepository : IRepository<Test>
    {
        IEnumerable<Test> GetTestsByCategoryId(int id);

        IEnumerable<Test> GetTestsByTitleKeyWord(string keyWord);
    }
}
