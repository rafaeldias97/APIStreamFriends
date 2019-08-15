using APIStreamFriends.domain.domain.Models;
using APIStreamFriends.presentation.webapi.Models;
using AutoMapper;

namespace APIStreamFriends.presentation.webapi.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteVM, Cliente>();
            CreateMap<SeguidorVM, Seguidor>();
        }
    }
}