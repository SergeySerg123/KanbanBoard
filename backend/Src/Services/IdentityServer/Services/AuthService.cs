﻿using AutoMapper;
using KanbanBoard.Services.IdentityServer.Data;
using KanbanBoard.Services.IdentityServer.Data.Entities;
using KanbanBoard.Services.IdentityServer.DTO.Auth;
using KanbanBoard.Services.IdentityServer.DTO.User;
using KanbanBoard.Services.IdentityServer.Helpers;
using KanbanBoard.Services.IdentityServer.JWT;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Services.IdentityServer.Services
{
    public sealed class AuthService
    {
        private readonly IdentityContext _context;
        private readonly JwtFactory _jwtFactory;      
        private readonly IMapper _mapper;

        public AuthService(IdentityContext context, IMapper mapper, JwtFactory jwtFactory) 
        {
            _context = context;
            _mapper = mapper;
            _jwtFactory = jwtFactory;
        }

        public async Task<AuthUserDTO> Authorize(UserLoginDTO userDto)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (userEntity == null)
            {
                //throw new NotFoundException(nameof(User));
            }

            if (!SecurityHelper.ValidatePassword(userDto.Password, userEntity.Password, userEntity.Salt))
            {
                //throw new InvalidUsernameOrPasswordException();
            }

            var token = await GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var user = _mapper.Map<UserDTO>(userEntity);

            return new AuthUserDTO
            {
                User = user,
                Token = token
            };
        }

        public async Task<AccessTokenDTO> GenerateAccessToken(string userId, string userName, string email)
        {
            var refreshToken = _jwtFactory.GenerateRefreshToken();

            _context.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                UserId = userId
            });

            await _context.SaveChangesAsync();

            var accessToken = await _jwtFactory.GenerateAccessToken(userId, userName, email);

            return new AccessTokenDTO(accessToken, refreshToken);
        }

        public async Task<AccessTokenDTO> RefreshToken(RefreshTokenDTO dto)
        {
            var userId = _jwtFactory.GetUserIdFromToken(dto.AccessToken, dto.SigningKey);
            var userEntity = await _context.Users.FindAsync(userId);

            if (userEntity == null)
            {
                //throw new NotFoundException(nameof(User), userId);
            }

            var rToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == dto.RefreshToken && t.UserId == userId);

            if (rToken == null)
            {
                //throw new InvalidTokenException("refresh");
            }

            if (!rToken.IsActive)
            {
                //throw new ExpiredRefreshTokenException();
            }

            var jwtToken = await _jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.UserName, userEntity.Email);
            var refreshToken = _jwtFactory.GenerateRefreshToken();

            _context.RefreshTokens.Remove(rToken); // delete the token we've exchanged
            _context.RefreshTokens.Add(new RefreshToken // add the new one
            {
                Token = refreshToken,
                UserId = userEntity.Id
            });

            await _context.SaveChangesAsync();

            return new AccessTokenDTO(jwtToken, refreshToken);
        }

        public async Task RevokeRefreshToken(string refreshToken, string userId)
        {
            var rToken = _context.RefreshTokens.FirstOrDefault(t => t.Token == refreshToken && t.UserId == userId);

            if (rToken == null)
            {
                //throw new InvalidTokenException("refresh");
            }

            _context.RefreshTokens.Remove(rToken);
            await _context.SaveChangesAsync();
        }

    }
}