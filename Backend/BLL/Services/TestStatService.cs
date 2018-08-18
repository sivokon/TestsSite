using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

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


        public void Add(TestStatDTO entity)
        {
            _unitOfWork.TestStatistics.DeleteNotFinishedTestStatisticsByUserId(entity.UserId);
            TestStat stat = _mapper.Map<TestStat>(entity);
            _unitOfWork.TestStatistics.Add(stat);
            _unitOfWork.SaveChanges();
        }

        public void Update(TestStatDTO entity)
        {
            entity.Result = this.CalculateTestResult(entity);

            TestStat startedStat = _unitOfWork.TestStatistics.GetNotFinishedTestByUserId(entity.UserId);
            startedStat.Result = entity.Result;
            startedStat.EndTime = entity.EndTime;
            startedStat.Answers = _mapper.Map<ICollection<Answer>>(entity.Answers);

            _unitOfWork.TestStatistics.Update(startedStat);
            _unitOfWork.SaveChanges();
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

        private int CalculateTestResult(TestStatDTO entity)
        {
            List<CorrectAnswer> corrAnswers = (List<CorrectAnswer>)_unitOfWork.CorrectAnswers.GetCorrectAnswersByTestId(entity.TestId);

            //Dictionary<int, int> answers = new Dictionary<int, int>();
            //for (int i = 0; i < entity.Answers.Count; i++)
            //{
            //    foreach (CorrectAnswer corrAnsw in corrAnswers)
            //    {
            //        if (corrAnsw.QuestionId == entity.Answers[i].QuestionId)
            //        {
            //            if (entity.Answers[i].OptionId == corrAnsw.OptionId)
            //            {
            //                answers[corrAnswers[i].QuestionId]++;
            //                entity.Answers[i].IsCorrect = true;
            //                break;
            //            }
            //            else
            //            {
            //                entity.Answers[i].IsCorrect = false;
            //            }
            //        }
            //    }
            //}



            //List<CorrectAnswer> corrAnswers = (List<CorrectAnswer>)_unitOfWork.CorrectAnswers.GetCorrectAnswersByTestId(entity.TestId);
            int numOfRightAnsw = 0;

            for (int i = 0; i < corrAnswers.Count; i++)
            {
                foreach (CorrectAnswer corrAnsw in corrAnswers)
                {
                    if (corrAnsw.QuestionId == entity.Answers[i].QuestionId)
                    {
                        if (entity.Answers[i].OptionId == corrAnswers[i].OptionId)
                        {
                            numOfRightAnsw++;
                            entity.Answers[i].IsCorrect = true;
                        }
                        else
                        {
                            entity.Answers[i].IsCorrect = false;
                        }
                    }
                }
            }

            return numOfRightAnsw * 100 / corrAnswers.Count;
        }


    }
}
