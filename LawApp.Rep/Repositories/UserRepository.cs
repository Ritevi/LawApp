using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
           
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));

            return VerifyHashedPassword(user.Password, password);
        }

        public async Task<User> CreateUserAsync(RegisterViewModel registerViewModel)
        {
            var dbContext = dbFactory.CreateContext();

            var user = new User() {Email = registerViewModel.Email, Password = HashPassword(registerViewModel.Password)};
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            var dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            var src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            var dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            var buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return AreHashesEqual(buffer3, buffer4);
        }

        private bool AreHashesEqual(IReadOnlyList<byte> firstHash, IReadOnlyList<byte> secondHash)
        {
            var minHashLength = firstHash.Count <= secondHash.Count ? firstHash.Count : secondHash.Count;
            var xor = firstHash.Count ^ secondHash.Count;
            for (var i = 0; i < minHashLength; i++)
            {
                xor |= firstHash[i] ^ secondHash[i];
            }
            return 0 == xor;
        }
    }
}
