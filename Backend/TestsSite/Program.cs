using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL_EF.EF;
using DAL_Common.Models;
using DAL_EF;
using DAL_EF.Repositories;

namespace TestsSite
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestDbContext"].ConnectionString;
            TestDbContext context = new TestDbContext(connectionString);
            UnitOfWork uow = new UnitOfWork(connectionString);
            TestRepository testRepository = new TestRepository(context);

            IEnumerable<Test> tests = testRepository.GetAll();
            foreach (Test test in tests)
            {
                Console.WriteLine(test.Title + ", " + test.Descr);
            }
            Console.WriteLine();


            //TestStatRepository tsRepo = new TestStatRepository(context);
            //Answer a1 = new Answer()
            //{
            //    QuestionId = 1,
            //    OptionIndex = 1
            //};
            //Answer a2 = new Answer()
            //{
            //    QuestionId = 2,
            //    OptionIndex = 2
            //};
            //Answer a3 = new Answer()
            //{
            //    QuestionId = 3,
            //    OptionIndex = 3
            //};
            //TestStat testStat = new TestStat()
            //{
            //    TestId = 1,
            //    UserId = "1",
            //    StartTime = DateTime.Now,
            //    EndTime = DateTime.Now,
            //    Result = 100,
            //    Answers = new List<Answer>() { a1, a2, a3 }
            //};
            //tsRepo.Add(testStat);


            Console.WriteLine("THE END");
            Console.ReadLine();
        }
    }
}
