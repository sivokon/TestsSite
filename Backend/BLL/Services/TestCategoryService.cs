using System.Collections.Generic;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class TestCategoryService : ITestCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TestCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(TestCategoryDTO entity)
        {
            TestCategory category = _mapper.Map<TestCategory>(entity);
            _unitOfWork.TestCategories.Add(category);
            _unitOfWork.SaveChanges();
        }

        public void Update(TestCategoryDTO entity)
        {
            TestCategory category = _mapper.Map<TestCategory>(entity);
            _unitOfWork.TestCategories.Update(category);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.TestCategories.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public TestCategoryDTO GetById(int id)
        {
            TestCategory category = _unitOfWork.TestCategories.GetById(id);
            return _mapper.Map<TestCategoryDTO>(category);
        }

        public IEnumerable<TestCategoryDTO> GetAll()
        {
            IEnumerable<TestCategory> tests = _unitOfWork.TestCategories.GetAll();
            return _mapper.Map<IEnumerable<TestCategoryDTO>>(tests);
        }

        public IEnumerable<TestCategoryDTO> GetCategoriesByTitleKeyWord(string keyWord)
        {
            IEnumerable<TestCategory> tests = _unitOfWork.TestCategories.GetCategoriesByTitleKeyWord(keyWord);
            return _mapper.Map<IEnumerable<TestCategoryDTO>>(tests);
        }

    }
}
