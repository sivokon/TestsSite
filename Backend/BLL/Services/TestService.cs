using System.Collections.Generic;
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
            Test test = _mapper.Map<Test>(entity);
            _unitOfWork.Tests.Add(test);
            _unitOfWork.SaveChanges();
        }

        public void Update(TestDTO entity)
        {
            Test test = _mapper.Map<Test>(entity);
            _unitOfWork.Tests.Update(test);
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

    }
}
