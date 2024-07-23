using AutoMapper;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;
using StillMeBackend.MessengerAPI.DTO;

namespace StillMeBackend.MessengerAPI.Services;

public class ChatService: ServiceBase<Chat, ChatDto>
{
    public ChatService(IRepository<Chat> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}