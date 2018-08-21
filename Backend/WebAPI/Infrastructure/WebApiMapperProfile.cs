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
            this.CreateMap<TestDTO, NewTestBindingModel>().ReverseMap();

            this.CreateMap<QuestionDTO, NewQuestionBindingModel>().ReverseMap();            

            this.CreateMap<QuestionDTO, QuestionBindingModel>().ReverseMap();

            this.CreateMap<QuestionDTO, QuestionViewModel>().ReverseMap();

            this.CreateMap<OptionDTO, NewOptionBindingModel>().ReverseMap();

            this.CreateMap<OptionDTO, OptionBindingModel>().ReverseMap();

            this.CreateMap<OptionDTO, OptionViewModel>().ReverseMap();
        }
    }
}