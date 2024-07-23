using AutoMapper;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;
using StillMeBackend.MessengerAPI.DTO;

namespace StillMeBackend.MessengerAPI.Services;

public class MessageService: ServiceBase<Message, MessageDto>
{
    public MessageService(IRepository<Message> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}