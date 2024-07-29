using AutoMapper;
using MessagingContracts.MessageContracts;
using StillMeGateway.DTO;

namespace StillMeGateway;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MessageDto, MessageCreate>();
        CreateMap<MessageResponse, MessageDto>();
    }
}