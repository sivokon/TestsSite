using DAL_Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.EF
{
    public class TestDbInitializer : DropCreateDatabaseIfModelChanges<TestDbContext>
    {
        protected override void Seed(TestDbContext context)
        {
            List<TestCategory> testCategories = new List<TestCategory>()
            {
                new TestCategory() { Id = 1, Title = "Geography" },
                new TestCategory() { Id = 2, Title = "Biology" }
            };
            testCategories.ForEach(x => context.TestCategories.Add(x));


            List<Test> tests = new List<Test>()
            {
                new Test() { Id = 1, Title = "Test1", Descr = "Description for test1", CreationDate = DateTime.Now, DurationMin = 20, CategoryId = 1 },
                new Test() { Id = 2, Title = "Test2", Descr = "Description for test2", CreationDate = DateTime.Now, DurationMin = 40, CategoryId = 1 },
                new Test() { Id = 3, Title = "Test3", Descr = "Description for test3", CreationDate = DateTime.Now, DurationMin = 60, CategoryId = 2 }
            };
            tests.ForEach(x => context.Tests.Add(x));


            List<Question> questions = new List<Question>()
            {
                new Question() { Id = 1, Body = "Test1, question1", Index = 1, TestId = 1 },
                new Question() { Id = 2, Body = "Test1, question2", Index = 2, TestId = 1 },
                new Question() { Id = 3, Body = "Test1, question3", Index = 3, TestId = 1 },
                //new Question() { Id = 4, Body = "Test1, question4", Index = 4, TestId = 1 },

                new Question() { Id = 4, Body = "Test2, question1", Index = 1, TestId = 2 },
                new Question() { Id = 5, Body = "Test2, question2", Index = 2, TestId = 2 },
                new Question() { Id = 6, Body = "Test2, question3", Index = 3, TestId = 2 },
                //new Question() { Id = 8, Body = "Test2, question4", Index = 4, TestId = 2 },

                new Question() { Id = 7, Body = "Test3, question1", Index = 1, TestId = 3 },
                new Question() { Id = 8, Body = "Test3, question2", Index = 2, TestId = 3 },
                new Question() { Id = 9, Body = "Test3, question3", Index = 3, TestId = 3 },
                //new Question() { Id = 12, Body = "Test3, question4", Index = 4, TestId = 3 },
            };
            questions.ForEach(x => context.Questions.Add(x));


            List<Option> options = new List<Option>()
            {
                new Option() { Id = 1, Body = "Test1, question1, option1", Index = 1, IsCorrect = true, QuestionId = 1 },
                new Option() { Id = 2, Body = "Test1, question1, option2", Index = 2, IsCorrect = false, QuestionId = 1 },
                new Option() { Id = 3, Body = "Test1, question1, option3", Index = 3, IsCorrect = false, QuestionId = 1 },

                new Option() { Id = 4, Body = "Test1, question2, option1", Index = 1, IsCorrect = true, QuestionId = 2 },
                new Option() { Id = 5, Body = "Test1, question2, option2", Index = 2, IsCorrect = false, QuestionId = 2 },
                new Option() { Id = 6, Body = "Test1, question2, option3", Index = 3, IsCorrect = false, QuestionId = 2 },

                new Option() { Id = 7, Body = "Test1, question3, option1", Index = 1, IsCorrect = true, QuestionId = 3 },
                new Option() { Id = 8, Body = "Test1, question3, option2", Index = 2, IsCorrect = false, QuestionId = 3 },
                new Option() { Id = 9, Body = "Test1, question3, option3", Index = 3, IsCorrect = false, QuestionId = 3 },


                new Option() { Id = 10, Body = "Test2, question1, option1", Index = 1, IsCorrect = true, QuestionId = 4 },
                new Option() { Id = 11, Body = "Test2, question1, option2", Index = 2, IsCorrect = false, QuestionId = 4 },
                new Option() { Id = 12, Body = "Test2, question1, option3", Index = 3, IsCorrect = false, QuestionId = 4 },

                new Option() { Id = 13, Body = "Test2, question2, option1", Index = 1, IsCorrect = true, QuestionId = 5 },
                new Option() { Id = 14, Body = "Test2, question2, option2", Index = 2, IsCorrect = false, QuestionId = 5 },
                new Option() { Id = 15, Body = "Test2, question2, option3", Index = 3, IsCorrect = false, QuestionId = 5 },

                new Option() { Id = 16, Body = "Test2, question3, option1", Index = 1, IsCorrect = true, QuestionId = 6 },
                new Option() { Id = 17, Body = "Test2, question3, option2", Index = 2, IsCorrect = false, QuestionId = 6 },
                new Option() { Id = 18, Body = "Test2, question3, option3", Index = 3, IsCorrect = false, QuestionId = 6 },


                new Option() { Id = 19, Body = "Test3, question1, option1", Index = 1, IsCorrect = true, QuestionId = 7 },
                new Option() { Id = 20, Body = "Test3, question1, option2", Index = 2, IsCorrect = false, QuestionId = 7 },
                new Option() { Id = 21, Body = "Test3, question1, option3", Index = 3, IsCorrect = false, QuestionId = 7 },

                new Option() { Id = 22, Body = "Test3, question2, option1", Index = 1, IsCorrect = true, QuestionId = 8 },
                new Option() { Id = 23, Body = "Test3, question2, option2", Index = 2, IsCorrect = false, QuestionId = 8 },
                new Option() { Id = 24, Body = "Test3, question2, option3", Index = 3, IsCorrect = false, QuestionId = 8 },

                new Option() { Id = 25, Body = "Test3, question3, option1", Index = 1, IsCorrect = true, QuestionId = 9 },
                new Option() { Id = 26, Body = "Test3, question3, option2", Index = 2, IsCorrect = false, QuestionId = 9 },
                new Option() { Id = 27, Body = "Test3, question3, option3", Index = 3, IsCorrect = false, QuestionId = 9 },
            };
            options.ForEach(x => context.Options.Add(x));


            //List<TestStat> testStatistics = new List<TestStat>()
            //{

            //};
            //testStatistics.ForEach(x => context.TestStatistics.Add(x));


            //List<Answer> answers = new List<Answer>()
            //{

            //};
            //answers.ForEach(x => context.Answers.Add(x));

        }
    }
}
