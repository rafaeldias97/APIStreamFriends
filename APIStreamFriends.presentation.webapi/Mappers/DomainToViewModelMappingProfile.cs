using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.presentation.webapi.Models;
using AutoMapper;

namespace APIStreamFriends.presentation.webapi.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteVM>();
            CreateMap<Seguidor, SeguidorVM>();
        }
    }
}