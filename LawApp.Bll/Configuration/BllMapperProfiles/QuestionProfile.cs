using AutoMapper;
using LawApp.Bll.Configuration.Extensions;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Bll.Configuration.BllMapperProfiles
{
    internal class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionViewModel>()
                .IgnoreAllNonExisting()
                .ForMember(q => q.PreviousQuestion, opt => opt.MapFrom(src => src.PreviousAnswer.Question));
        }
    }
}
