using AutoMapper;
using MessagingContracts;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;

namespace StillMeBackend.MessengerAPI.Services;

public class ChatService: ServiceBase<Chat, ChatBase>
{
    protected override ChatRepository _repository { get; }
    public ChatService(ChatRepository repository, IMapper mapper) : base(mapper)
    {
        _repository = repository;
    }
    
    public IEnumerable<ChatBase> GetChatsByUserId(string id)
    {
        return _mapper.Map<IEnumerable<ChatBase>>(_repository.GetChatsByUserId(id));
    }
    
}