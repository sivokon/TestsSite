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
        //IRepository<Test> Tests { get; }
        //IRepository<TestCategory> TestCategories { get; }
        //IRepository<Question> Questions { get; }
        //IRepository<Option> Options { get; }
        //IRepository<TestStat> TestStatistics { get; }
        //IRepository<Answer> Answers { get; }
        //void SaveChanges();

        ITestRepository Tests { get; }
        ITestCategoryRepository TestCategories { get; }
        IQuestionRepository Questions { get; }
        IOptionRepository Options { get; }
        ITestStatRepository TestStatistics { get; }
        IAnswerRepository Answers { get; }
        ICorrectAnswerRepository CorrectAnswers { get; }
        void SaveChanges();
    }
}
