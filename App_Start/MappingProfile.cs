using AutoMapper;
using Course.DTOs;
using Course.Models;

namespace Course.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }

    }
}