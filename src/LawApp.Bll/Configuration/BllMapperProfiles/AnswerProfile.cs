using AutoMapper;
using LawApp.Bll.Configuration.Extensions;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Bll.Configuration.BllMapperProfiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerViewModel>().IgnoreAllNonExisting();
        }
    }
}
