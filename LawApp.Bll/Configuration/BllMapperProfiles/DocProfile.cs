using AutoMapper;
using LawApp.Bll.Configuration.Extensions;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Bll.Configuration.BllMapperProfiles
{
    public class DocProfile : Profile
    {
        public DocProfile()
        {
            CreateMap<Doc, DocViewModel>().IgnoreAllNonExisting();
        }
    }
}