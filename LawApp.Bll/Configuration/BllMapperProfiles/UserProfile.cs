using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LawApp.Bll.Configuration.Extensions;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Bll.Configuration.BllMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserViewModel>().IgnoreAllNonExisting();
        }
    }
}
