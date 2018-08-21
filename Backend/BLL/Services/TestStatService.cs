using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;
using System;
using System.Linq;

namespace BLL.Services
{
    public class TestStatService : ITestStatService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TestStatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IEnumerable<TestStatDTO> GetTestStatisticsWithRelatedTestsByUserId(string id)
        {
            IEnumerable<TestStat> stats = _unitOfWork.TestStatistics.GetTestStatisticsWithRelatedTestsByUserId(id);
            return _mapper.Map<IEnumerable<TestStatDTO>>(stats);
        }

        public void StartTest(TestStatDTO startTestData)
        {
            _unitOfWork.TestStatistics.DeleteNotFinishedTestStatisticsByUserId(startTestData.UserId);

            startTestData.StartTime = DateTime.Now;
            TestStat stat = _mapper.Map<TestStat>(startTestData);
            _unitOfWork.TestStatistics.Add(stat);
            _unitOfWork.SaveChanges();
        }

        public void SaveCompletedTest(TestStatDTO endTestData)
        {
            endTestData.Result = this.CalculateTestResult(endTestData);

            TestStat startedTestData = _unitOfWork.TestStatistics.GetNotFinishedTestByUserId(endTestData.UserId);

            if (this.TestWasSentOnTime(startedTestData, endTestData))
            {
                startedTestData.Result = endTestData.Result;
                startedTestData.EndTime = DateTime.Now;
                startedTestData.Answers = _mapper.Map<ICollection<Answer>>(endTestData.Answers);

                _unitOfWork.TestStatistics.Update(startedTestData);
                _unitOfWork.SaveChanges();
            }            
        }


        private bool TestWasSentOnTime(TestStat startTestData, TestStatDTO endTestData)
        {
            int testDurMin = startTestData.Test.DurationMin;
            int actualTestDurMin = (endTestData.EndTime - DateTime.Now).Minutes - 1;

            return actualTestDurMin <= testDurMin;
        }

        private int CalculateTestResult(TestStatDTO entity)
        {
            List<Question> allQuestions = (List<Question>)_unitOfWork.Questions.GetQuestionsWithOptionsByTestId(entity.TestId);

            int numOfRightAnsw = 0;

            foreach (AnswerDTO answer in entity.Answers)
            {
                answer.PointValue = this.GetPointForAnswer(answer, allQuestions);

                if (answer.PointValue == 1)
                {
                    numOfRightAnsw++;
                }
            }

            return numOfRightAnsw * 100 / entity.Answers.Count;
        }

        private int GetPointForAnswer(AnswerDTO answer, List<Question> allQuestion)
        {
            foreach (Question question in allQuestion)
            {
                if (answer.QuestionId == question.Id)
                {
                    List<Option> corrOpts = question.Options.Where(option => option.IsCorrect == true).ToList();

                    if (this.ChosenOptionsAreCorrect(answer.AnswerOptions, corrOpts))
                    {
                        return 1;
                    }
                    break;
                }
            }
            return 0;
        }

        private bool ChosenOptionsAreCorrect(List<AnswerOptionDTO> chosenOptions, List<Option> correctOptions)
        {
            if (chosenOptions.Count != correctOptions.Count)
            {
                return false;
            }

            int numOfEqual = 0;

            foreach (AnswerOptionDTO chosenOption in chosenOptions)
            {
                foreach (Option corrOpt in correctOptions)
                {
                    if (chosenOption.OptionId == corrOpt.Id)
                    {
                        numOfEqual++;
                        break;
                    }
                }
            }

            return numOfEqual == correctOptions.Count;
        }


    }

}
