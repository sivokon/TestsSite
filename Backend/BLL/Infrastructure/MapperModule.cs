using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using AutoMapper;

namespace BLL.Infrastructure
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            this.Bind<IMapper>().ToMethod(ctx => new Mapper(config));
            //this.Bind<IMapper>().To<Mapper>().WithConstructorArgument(config);
        }
    }
}
