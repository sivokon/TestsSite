using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;
using System;

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
        
        
        public void StartTest(TestStatDTO entity)
        {
            _unitOfWork.TestStatistics.DeleteNotFinishedTestStatisticsByUserId(entity.UserId);

            TestStat stat = _mapper.Map<TestStat>(entity);
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
                startedTestData.EndTime = endTestData.EndTime;
                startedTestData.Answers = _mapper.Map<ICollection<Answer>>(endTestData.Answers);

                _unitOfWork.TestStatistics.Update(startedTestData);
                _unitOfWork.SaveChanges();
            }            
        }

        public TestStatDTO GetById(int id)
        {
            TestStat stat = _unitOfWork.TestStatistics.GetById(id);
            return _mapper.Map<TestStatDTO>(stat);
        }

        public IEnumerable<TestStatDTO> GetTestStatisticsByUserId(string id)
        {
            IEnumerable<TestStat> stats = _unitOfWork.TestStatistics.GetTestStatisticsByUserId(id);
            return _mapper.Map<IEnumerable<TestStatDTO>>(stats);
        }

        public IEnumerable<TestStatDTO> GetTestStatisticsWithRelatedTestsByUserId(string id)
        {
            IEnumerable<TestStat> stats = _unitOfWork.TestStatistics.GetTestStatisticsWithRelatedTestsByUserId(id);
            return _mapper.Map<IEnumerable<TestStatDTO>>(stats);
        }

        public TestStatDTO GetNotFinishedTestByUserId(string id)
        {
            // ne nuzhen
            TestStat stat = _unitOfWork.TestStatistics.GetNotFinishedTestByUserId(id);
            return _mapper.Map<TestStatDTO>(stat);
        }


        private bool TestWasSentOnTime(TestStat startTestData, TestStatDTO endTestData)
        {
            int testDurMin = startTestData.Test.DurationMin;
            int actualTestDurMin = (endTestData.EndTime - DateTime.Now).Minutes - 1;

            return actualTestDurMin <= testDurMin;
        }

        private int CalculateTestResult(TestStatDTO entity)
        {
            List<Question> questionsWithCorrectOptions = (List<Question>)_unitOfWork.Questions.GetQuestionWithCorrectOptionsByTestId(entity.TestId);
            
            int numOfRightAnsw = 0;

            foreach (AnswerDTO answer in entity.Answers)
            {
                answer.PointValue = this.GetPointForAnswer(answer, questionsWithCorrectOptions);

                if (answer.PointValue == 1)
                {
                    numOfRightAnsw++;
                }
            }

            return numOfRightAnsw * 100 / entity.Answers.Count;
        }

        private int GetPointForAnswer(AnswerDTO answer, List<Question> questionsWithCorrectOptions)
        {
            foreach (Question question in questionsWithCorrectOptions)
            {
                if (answer.QuestionId == question.Id)
                {
                    if (this.ChosenOptionsAreCorrect(answer.AnswerOptions, question.CorrectOptions))
                    {
                        return 1;
                    }
                    break;
                }
            }
            return 0;
        }

        private bool ChosenOptionsAreCorrect(ICollection<AnswerOptionDTO> chosenOptions, ICollection<CorrectOption> correctOptions)
        {
            if (chosenOptions.Count != correctOptions.Count)
            {
                return false;
            }

            int numOfEqual = 0;

            foreach (AnswerOptionDTO chosenOption in chosenOptions)
            {
                foreach (CorrectOption corrAnsw in correctOptions)
                {
                    if (chosenOption.OptionId == corrAnsw.OptionId)
                    {
                        numOfEqual++;
                        break;
                    }
                }
            }

            return numOfEqual == correctOptions.Count;
        }


    }


    public class TestSaveResult
    {
        public bool Succeeded { get; }
        public string[] Errors { get; }

        public TestSaveResult(bool succeeded)
        {
            this.Succeeded = succeeded;
        }

        public TestSaveResult(params string[] errors)
        {
            this.Errors = errors;
        }
    }

}
