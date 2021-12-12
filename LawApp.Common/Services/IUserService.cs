using System.Threading.Tasks;
using LawApp.Common.Models.Dto;
using LawApp.Common.Models.Dto.AuthModels;

namespace LawApp.Common.Services
{
    public interface IUserService
    {
        Task<bool> CheckUserByEmailAsync(string email);
        Task<bool> CheckPasswordByEmail(string email, string password);

        Task<UserViewModel> CreateUserAsync(RegisterViewModel registerViewModel);
    }
}
