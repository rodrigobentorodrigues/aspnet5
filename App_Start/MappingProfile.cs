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
            CreateMap<CustomerDTO, Customer>().ForMember((cust) => cust.Id, (opt) => opt.Ignore());
            //
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>().ForMember((mov) => mov.Id, (opt) => opt.Ignore());

            CreateMap<MembershipType, MembershipTypeDTO>();
            CreateMap<Genre, GenreDTO>();
        }

    }
}