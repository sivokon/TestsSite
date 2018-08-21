using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(QuestionDTO entity)
        {
            Question question = _mapper.Map<Question>(entity);
            _unitOfWork.Questions.Add(question);
            _unitOfWork.SaveChanges();
        }

        public void Update(QuestionDTO entity)
        {
            Question question = _mapper.Map<Question>(entity);
            _unitOfWork.Questions.Update(question);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Questions.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public QuestionDTO GetById(int id)
        {
            Question question = _unitOfWork.Questions.GetById(id);
            return _mapper.Map<QuestionDTO>(question);
        }

        public IEnumerable<QuestionDTO> GetQuestionsByTestId(int id)
        {
            IEnumerable<Question> questions = _unitOfWork.Questions.GetQuestionsByTestId(id);
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public QuestionDTO GetQuestionByIndexAndTestId(int index, int testId)
        {
            Question question = _unitOfWork.Questions.GetQuestionByIndexAndTestId(index, testId);
            return _mapper.Map<QuestionDTO>(question);
        }

        public IEnumerable<QuestionDTO> GetQuestionsWithRelatedOptionsByTestId(int id)
        {
            IEnumerable<Question> questions = _unitOfWork.Questions.GetQuestionsWithOptionsByTestId(id);
            return _mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

    }
}
