using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BLL.Intrefaces;
using BLL.Services;

namespace BLL.Infrastructure
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestService>().To<TestService>();
            this.Bind<ITestCategoryService>().To<TestCategoryService>();
            this.Bind<IQuestionService>().To<QuestionService>();
            this.Bind<IOptionService>().To<OptionService>();
            this.Bind<ITestStatService>().To<TestStatService>();
            this.Bind<IAnswerService>().To<AnswerService>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IRoleService>().To<RoleService>();
        }
    }
}
