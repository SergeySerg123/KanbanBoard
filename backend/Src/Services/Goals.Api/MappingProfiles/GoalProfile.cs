using AutoMapper;
using KanbanBoard.Services.Goals.Api.DTO;
using KanbanBoard.Services.Goals.Api.Models;
using MongoDB.Bson;

namespace KanbanBoard.Services.Goals.Api.MappingProfiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<GoalDTO, Goal>()
                .ForMember(c => c.AuthorId, src => src.MapFrom(x => new ObjectId(x.AuthorId)))
                .ForMember(c => c.BoardId, src => src.MapFrom(x => new ObjectId(x.BoardId)));

            CreateMap<Goal, GoalDTO>()
                .ForMember(c => c.AuthorId, src => src.MapFrom(x => x.AuthorId.ToString()))
                .ForMember(c => c.BoardId, src => src.MapFrom(x => x.BoardId.ToString()));
        }
    }
}
