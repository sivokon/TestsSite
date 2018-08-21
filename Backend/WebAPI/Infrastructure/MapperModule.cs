using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Ninject.Modules;
using BLL.Infrastructure;

namespace WebAPI.Infrastructure
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
                cfg.AddProfile(new WebApiMapperProfile());
            });

            this.Bind<IMapper>().ToMethod(ctx => new Mapper(config));
        }
    }
}