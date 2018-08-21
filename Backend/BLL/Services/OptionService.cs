using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class OptionService : IOptionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(OptionDTO entity)
        {
            Option option = _mapper.Map<Option>(entity);
            _unitOfWork.Options.Add(option);
            _unitOfWork.SaveChanges();
        }

        public void Update(OptionDTO entity)
        {
            Option option = _mapper.Map<Option>(entity);
            _unitOfWork.Options.Update(option);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Options.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<OptionDTO> GetOptionsByQuestionId(int id)
        {
            IEnumerable<Option> options = _unitOfWork.Options.GetOptionsByQuestionId(id);
            return _mapper.Map<IEnumerable<OptionDTO>>(options);
        }

    }
}
