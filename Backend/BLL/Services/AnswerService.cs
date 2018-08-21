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

        public IEnumerable<AnswerDTO> GetAnswersWithAnswerOptionsByTestStatisticId(int id)
        {
            IEnumerable<Answer> answers = _unitOfWork.Answers.GetAnswersWithAnswerOptionsByTestStatisticId(id);
            return _mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

    }
}
