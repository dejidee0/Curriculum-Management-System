using AutoMapper;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Profiles
{
    public class CMSProfile : Profile
    {
        public CMSProfile()
        {
            CreateMap<AddLessonDTO, Lesson>().ReverseMap();
            CreateMap<Lesson, LessonResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.SquadNumber, opt => opt.MapFrom(src => src.SquadNumber))
                .ForMember(dest => dest.PublicId, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated)).ReverseMap();
        }
    }
}