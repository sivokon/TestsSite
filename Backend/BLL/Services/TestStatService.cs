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
            entity.Result = CalculateTestResult(entity);
            TestStat stat = _mapper.Map<TestStat>(entity);
            _unitOfWork.TestStatistics.Add(stat);
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

        private int CalculateTestResult(TestStatDTO entity)
        {
            List<Question> questions = (List<Question>)_unitOfWork.Questions.GetQuestionsByTestId(entity.TestId);           
            int numOfRightAnsw = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                //for (int j = 0; j < questions[i].Options.Count; j++)
                //{
                  
                //}
                foreach (Option option in questions[i].Options)
                {
                    if (option.IsCorrect && option.Index == entity.Answers[i].OptionIndex)
                    {
                        numOfRightAnsw++;
                    }
                }
            }
            return numOfRightAnsw * 100 / questions.Count;
        }


    }
}
