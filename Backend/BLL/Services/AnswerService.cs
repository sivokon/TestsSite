using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(AnswerDTO entity)
        {
            Answer answer = _mapper.Map<Answer>(entity);
            _unitOfWork.Answers.Add(answer);
            _unitOfWork.SaveChanges();
        }

        public AnswerDTO GetById(int id)
        {
            Answer answer = _unitOfWork.Answers.GetById(id);
            return _mapper.Map<AnswerDTO>(answer);
        }

        //public IEnumerable<AnswerDTO> GetAnswersByTestStatisticId(int id)
        //{
        //    IEnumerable<Answer> answers = _unitOfWork.Answers.GetAnswersByTestStatisticId(id);
        //    return _mapper.Map<IEnumerable<AnswerDTO>>(answers);
        //}

        public IEnumerable<AnswerDTO> GetAnswersWithAnswerOptionsByTestStatisticId(int id)
        {
            IEnumerable<Answer> answers = _unitOfWork.Answers.GetAnswersWithAnswerOptionsByTestStatisticId(id);
            return _mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

    }
}
