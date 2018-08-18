using System.Configuration;
using BLL.Infrastructure;
using BLL.Intrefaces;
using BLL.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["TestDbContext"].ConnectionString;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<ITestCategoryService>().To<TestCategoryService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IOptionService>().To<OptionService>();
            kernel.Bind<ITestStatService>().To<TestStatService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();

            kernel.Load(new MapperModule(), new UnitOfWorkModule(connectionString));
        }        
    }
}