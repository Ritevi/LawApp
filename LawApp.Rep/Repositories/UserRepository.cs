using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Models.Dto.AuthModels;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace LawApp.Rep.Repositories
{
    internal  class UserRepository : ItemHasIdRepository<User>, IUserRepository
    {
        public UserRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory)
        {
        }

        public async Task<bool> CheckUserByEmailAsync(string email)
        {
            var dbContext = dbFactory.CreateContext();
            return await dbContext.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<bool> CheckPasswordByEmail(string email, string password)
        {
            var dbContext = dbFactory.CreateContext();
            return await dbContext.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()) && u.Password.Equals(password));
        }

        public async Task<User> CreateUserAsync(RegisterViewModel registerViewModel)
        {
            var dbContext = dbFactory.CreateContext();
            var user = new User() {Email = registerViewModel.Email, Password = registerViewModel.Password};
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
