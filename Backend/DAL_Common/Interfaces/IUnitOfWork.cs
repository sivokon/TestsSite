using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITestRepository Tests { get; }
        ITestCategoryRepository TestCategories { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
        ITestStatRepository TestStatistics { get; }
        IAnswerRepository Answers { get; }
        void SaveChanges();
    }
}
