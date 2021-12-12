using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Models.Dto.AuthModels;

namespace LawApp.Common.Repositories
{
    public interface IUserRepository : IHasIdRepository<User>
    {
        Task<bool> CheckUserByEmailAsync(string email);
        Task<bool> CheckPasswordByEmail(string email, string password);
        Task<User> CreateUserAsync(RegisterViewModel registerViewModel);
    }
}
