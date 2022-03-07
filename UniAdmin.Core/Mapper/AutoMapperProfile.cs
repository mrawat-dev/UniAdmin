using AutoMapper;
using UniAdmin.Contracts.Data.Entities;
using UniAdmin.Contracts.DTO;

namespace UniAdmin.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Deal, DealDTO>();
        }
    }
}
