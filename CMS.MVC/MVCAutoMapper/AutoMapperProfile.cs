using AutoMapper;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.MVC.MVCAutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, GetuserByIdDto>();
            CreateMap<ApplicationUser, GetAllUsersDto>();
        }
    }
}
