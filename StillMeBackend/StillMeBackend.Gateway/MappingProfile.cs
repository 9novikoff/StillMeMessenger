using AutoMapper;
using MessagingContracts.MessageContracts;
using StillMeBackend.Gateway.DTO;

namespace StillMeBackend.Gateway;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MessageDto, MessageCreate>();
        CreateMap<MessageResponse, MessageDto>();
        CreateMap<User, UserViewDto>();
    }
}