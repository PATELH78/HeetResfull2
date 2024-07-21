using AutoMapper;
using Heetapp1.Models;

namespace Heetapp1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
