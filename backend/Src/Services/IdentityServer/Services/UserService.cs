using AutoMapper;
using KanbanBoard.Services.IdentityServer.Data;
using KanbanBoard.Services.IdentityServer.DTO.User;
using KanbanBoard.Services.IdentityServer.Entities;
using KanbanBoard.Services.IdentityServer.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Services.IdentityServer.Services
{
    public class UserService
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;

        public UserService(IdentityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDTO>> GetUsers()
        {
            var users = await _context.Users
                .ToListAsync();

            return _mapper.Map<ICollection<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await GetUserByIdInternal(id);
            if (user == null)
            {
                //throw new NotFoundException(nameof(User), id);
            }

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(UserRegisterDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var salt = SecurityHelper.GetRandomBytes();

            userEntity.Salt = Convert.ToBase64String(salt);
            userEntity.Password = SecurityHelper.HashPassword(userDto.Password, salt);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            var userEntity = await GetUserByIdInternal(userDto.Id);
            if (userEntity == null)
            {
                //throw new NotFoundException(nameof(User), userDto.Id);
            }

            var timeNow = DateTime.Now;

            userEntity.Email = userDto.Email;
            userEntity.UserName = userDto.UserName;
            userEntity.UpdatedAt = timeNow;
            userEntity.URL = userDto.Avatar;
            

            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string userId)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (userEntity == null)
            {
                //throw new NotFoundException(nameof(User), userId);
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserByIdInternal(string id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
