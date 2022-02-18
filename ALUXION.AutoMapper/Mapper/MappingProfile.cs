using ALUXION.Domain;
using ALUXION.DTOs;
using AutoMapper;
namespace ALUXION.AutoMapper.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
