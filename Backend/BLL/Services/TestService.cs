using System.Collections.Generic;
using System;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(TestDTO entity)
        {
            entity.CreationDate = DateTime.Now;
            this.SetIndicesInTest(entity);

            Test test = _mapper.Map<Test>(entity);
            _unitOfWork.Tests.Add(test);

            _unitOfWork.SaveChanges();
        }

        public void Update(int testId, TestDTO entity)
        {
            Test oldVersionTest = _unitOfWork.Tests.GetById(testId);

            entity.CreationDate = oldVersionTest.CreationDate;
            this.SetIndicesInTest(entity);

            IEnumerable<TestStat> statsOfDelTest = _unitOfWork.TestStatistics.GetTestStatisticsWithAnswersByTestId(testId);          

            Test test = _mapper.Map<Test>(entity);
            test.TestStatistics = (ICollection<TestStat>)statsOfDelTest;
            _unitOfWork.Tests.Add(test);

            _unitOfWork.Tests.Delete(testId);

            _unitOfWork.SaveChanges();

        }

        public void Delete(int id)
        {
            _unitOfWork.Tests.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<TestDTO> GetAll()
        {
            IEnumerable<Test> tests = _unitOfWork.Tests.GetAll();
            return _mapper.Map<IEnumerable<TestDTO>>(tests);
        }

        public TestDTO GetById(int id)
        {
            Test test = _unitOfWork.Tests.GetById(id);
            return _mapper.Map<TestDTO>(test);
        }

        public IEnumerable<TestDTO> GetTestsByCategoryId(int id)
        {
            IEnumerable<Test> tests = _unitOfWork.Tests.GetTestsByCategoryId(id);
            return _mapper.Map<IEnumerable<TestDTO>>(tests);
        }

        public IEnumerable<TestDTO> GetTestsByTitleKeyWord(string keyWord)
        {
            IEnumerable<Test> tests = _unitOfWork.Tests.GetTestsByTitleKeyWord(keyWord);
            return _mapper.Map<IEnumerable<TestDTO>>(tests);
        }


        private void SetIndicesInTest(TestDTO newTest)
        {
            if (newTest.Questions == null)
            {
                return;
            }
            
            this.SetQuestionsIndices(newTest.Questions);

            foreach (QuestionDTO question in newTest.Questions)
            {
                this.SetOptionsIndices(question.Options);
            }
        }

        private void SetQuestionsIndices(List<QuestionDTO> questions)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].Index = i + 1;
            }
        }

        private void SetOptionsIndices(List<OptionDTO> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                options[i].Index = i + 1;
            }
        }

        //private void SetCorrectAnswers(TestDTO testWithAnsw, Test newAddedTest)
        //{
        //    for (int i = 0; i < testWithAnsw.Questions.Count; i++)
        //    {
        //        foreach (Question question in newAddedTest.Questions)
        //        {
        //            if (testWithAnsw.Questions[i].Index == question.Index)
        //            {
        //                for (int j = 0; j < testWithAnsw.Questions[i].Options.Count; j++)
        //                {
        //                    foreach (Option option in question.Options)
        //                    {
        //                        if (testWithAnsw.Questions[i].Options[j].Index == option.Index)
        //                        {
        //                            if (testWithAnsw.Questions[i].Options[j].IsCorrect == true)
        //                            {
        //                                question.CorrectOptions.Add(new CorrectOption() { OptionId = option.Id });
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        private void SetAnswersOfExistingTest(TestDTO testWithAnsw, Test newAddedTest)
        {
            //foreach (QuestionDTO newQuestion in testWithAnsw.Questions)
            //{
            //    foreach (Question oldQuestion)
            //}
        }

    }
}
