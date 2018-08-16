using Ninject.Modules;
using DAL_Common.Interfaces;
using DAL_EF;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }

    }
}
