using AutoMapper;
using TodoList_MySQL.DTOs;
using TodoList_MySQL.Model;

namespace TodoList_MySQL.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Todo, TodoDto>();
            CreateMap<TodoGroup, TodoGroupDto>();
            CreateMap<Member, MemberDto>()
                .ForMember(
                    dest => dest.PhotoUrl, 
                    opt => opt.MapFrom(
                        src => src.Photos.FirstOrDefault(x => x.isMain).Url
                    )
                 );
            CreateMap<Photo, PhotoDto>();
            CreateMap<Video, VideoDto>();
        }
    }
}
