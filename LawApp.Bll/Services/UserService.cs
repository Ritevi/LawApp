using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LawApp.Common.Models.Dto;
using LawApp.Common.Models.Dto.AuthModels;
using LawApp.Common.Repositories;
using LawApp.Common.Services;

namespace LawApp.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<bool> CheckUserByEmailAsync(string email)
        {
            return await _userRepository.CheckUserByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordByEmail(string email, string password)
        {
            return await _userRepository.CheckPasswordByEmail(email, password);
        }

        public async Task<UserViewModel> CreateUserAsync(RegisterViewModel registerViewModel)
        {
            var user = await _userRepository.CreateUserAsync(registerViewModel);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
