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

            this.CreateMap<Question, QuestionDTO>().ReverseMap();

            this.CreateMap<Option, OptionDTO>().ReverseMap();

            this.CreateMap<TestStat, TestStatDTO>().ReverseMap();

            this.CreateMap<Answer, AnswerDTO>().ReverseMap();
        }
    }
}
