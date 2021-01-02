using AutoMapper;
using IdentityServer.DTO.User;
using IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.MappingProfiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            //CreateMap<UserDTO, User>()
            //    .ForMember(dest => dest.Avatar, src => src.MapFrom(s => string.IsNullOrEmpty(s.Avatar) ? null : new Image { URL = s.Avatar }));

            //CreateMap<User, UserDTO>()
            //   .ForMember(dest => dest.Avatar, src => src.MapFrom(s => s.Avatar != null ? s.Avatar.URL : string.Empty));

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
