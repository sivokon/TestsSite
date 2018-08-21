using AutoMapper;
using BLL.DTO;
using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Infrastructure
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            this.CreateMap<TestDTO, NewTestBindingModel>();

            this.CreateMap<QuestionDTO, NewTestQuestionBindingModel>();            

            this.CreateMap<QuestionDTO, QuestionBindingModel>();

            this.CreateMap<OptionDTO, NewTestOptionBindingModel>();

            this.CreateMap<OptionDTO, OptionBindingModel>();
        }
    }
}