using AutoMapper;
using MessagingContracts;
using MessagingContracts.ChatMessaging;
using StillMeBackend.MessengerAPI.DAL;

namespace StillMeBackend.MessengerAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Chat, ChatBase>();
        CreateMap<ChatBase, Chat>();
        CreateMap<IEnumerable<ChatBase>, ChatListResponse>().ForMember(d => d.Content, cf => cf.MapFrom(src => src));
    }
}