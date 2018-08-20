using AutoMapper;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Test, TestDTO>().ReverseMap();

            this.CreateMap<TestCategory, TestCategoryDTO>().ReverseMap();

            this.CreateMap<Question, QuestionDTO>()
                .ForMember(quesDTO => quesDTO.Options, x => x.MapFrom(ques => ques.Options))                   
                .ReverseMap();

            this.CreateMap<Option, OptionDTO>().ReverseMap();

            this.CreateMap<TestStat, TestStatDTO>()
                .ForMember(statDTO => statDTO.Test, x => x.MapFrom(stat => stat.Test))
                .ReverseMap();

            this.CreateMap<Answer, AnswerDTO>().ReverseMap();

            this.CreateMap<AnswerOption, AnswerOptionDTO>().ReverseMap();

            this.CreateMap<CorrectOption, CorrectOptionDTO>().ReverseMap();

            this.CreateMap<User, UserDTO>().ReverseMap();

            this.CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
