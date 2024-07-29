using AutoMapper;
using MessagingContracts;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;

namespace StillMeBackend.MessengerAPI.Services;

public class MessageService: ServiceBase<Message, MessageBase>
{
    protected override MessageRepository _repository { get; }
    public MessageService(MessageRepository repository, IMapper mapper) : base(mapper)
    {
        _repository = repository;
    }

    public IEnumerable<MessageBase> GetMessagePageForUserId(string UserId, int pageNumber, int pageSize)
    {
        var messages = _repository.GetAll();

        return _mapper.Map<IEnumerable<MessageBase>>(messages.Where(m => m.UserId == UserId).Skip((pageNumber - 1) * pageSize).Take(pageSize));
    }
}