using AutoMapper;
using KanbanBoard.Services.IdentityServer.DTO.User;
using KanbanBoard.Services.IdentityServer.Entities;

namespace KanbanBoard.Services.IdentityServer.MappingProfiles
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
