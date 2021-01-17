using AutoMapper;
using Course.DTOs;
using Course.Models;

namespace Course.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ForMember((cust) => cust.Id,  (opt) => opt.Ignore());
            CreateMap<CustomerDTO, Customer>();
            //
            CreateMap<Movie, MovieDTO>().ForMember((mov) => mov.Id, (opt) => opt.Ignore());
            CreateMap<MovieDTO, Movie>();
        }

    }
}