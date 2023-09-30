using AutoMapper;
using YaqeenDAL.Model;
using YaqeenServices.DTOs;

namespace YaqeenServices
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserCreateDto,User>()
                .ForMember(dest => dest.Active, source => source.MapFrom(s => true));
        }
    }
}
