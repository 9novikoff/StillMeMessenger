using AutoMapper;
using MessagingContracts;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;

namespace StillMeBackend.MessengerAPI.Services;

public class ChatMemberService: ServiceBase<ChatMember, ChatMemberBase>
{
    protected override ChatMemberRepository _repository { get; }
    
    public ChatMemberService(ChatMemberRepository repository, IMapper mapper) : base(mapper)
    {
        _repository = repository;
    }

}