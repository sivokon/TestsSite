using System;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using DAL_EF.EF;
using DAL_EF.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF
{
    public class UnitOfWork : IUnitOfWork
    {
        //private TestDbContext _context;
        //private Lazy<IRepository<Test>> _testRepository;
        //private Lazy<IRepository<TestCategory>> _testCategoryRepository;
        //private Lazy<IRepository<Question>> _questionRepository;
        //private Lazy<IRepository<Option>> _optionRepository;
        //private Lazy<IRepository<TestStat>> _testStatRepository;
        //private Lazy<IRepository<Answer>> _answerRepository;

        //public UnitOfWork(string connectionString)
        //{
        //    _context = new TestDbContext(connectionString);
        //    _testRepository = new Lazy<IRepository<Test>>(() => new TestRepository(_context));
        //    _testCategoryRepository = new Lazy<IRepository<TestCategory>>(() => new TestCategoryRepository(_context));
        //    _questionRepository = new Lazy<IRepository<Question>>(() => new QuestionRepository(_context));
        //    _optionRepository = new Lazy<IRepository<Option>>(() => new OptionRepository(_context));
        //    _testStatRepository = new Lazy<IRepository<TestStat>>(() => new TestStatRepository(_context));
        //    _answerRepository = new Lazy<IRepository<Answer>>(() => new AnswerRepository(_context));
        //}

        //public IRepository<Test> Tests => _testRepository.Value;
        //public IRepository<TestCategory> TestCategories => _testCategoryRepository.Value;
        //public IRepository<Question> Questions => _questionRepository.Value;
        //public IRepository<Option> Options => _optionRepository.Value;
        //public IRepository<TestStat> TestStatistics => _testStatRepository.Value;
        //public IRepository<Answer> Answers => _answerRepository.Value;

        private TestDbContext _context;
        private Lazy<ITestRepository> _testRepository;
        private Lazy<ITestCategoryRepository> _testCategoryRepository;
        private Lazy<IQuestionRepository> _questionRepository;
        private Lazy<IOptionRepository> _optionRepository;
        private Lazy<ITestStatRepository> _testStatRepository;
        private Lazy<IAnswerRepository> _answerRepository;

        private Lazy<IUserRepository> _userRepository;
        private Lazy<IRoleRepository> _roleRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new TestDbContext(connectionString);
            _testRepository = new Lazy<ITestRepository>(() => new TestRepository(_context));
            _testCategoryRepository = new Lazy<ITestCategoryRepository>(() => new TestCategoryRepository(_context));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(_context));
            _optionRepository = new Lazy<IOptionRepository>(() => new OptionRepository(_context));
            _testStatRepository = new Lazy<ITestStatRepository>(() => new TestStatRepository(_context));
            _answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(_context));

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(_context));
        }

        public ITestRepository Tests => _testRepository.Value;
        public ITestCategoryRepository TestCategories => _testCategoryRepository.Value;
        public IQuestionRepository Questions => _questionRepository.Value;
        public IOptionRepository Options => _optionRepository.Value;
        public ITestStatRepository TestStatistics => _testStatRepository.Value;
        public IAnswerRepository Answers => _answerRepository.Value;

        public IUserRepository Users => _userRepository.Value;
        public IRoleRepository Roles => _roleRepository.Value;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                this._context.Dispose();
            }
            disposed = true;
        }

    }
}
