using AutoMapper;
using StillMeBackend.MessengerAPI.DAL;
using StillMeBackend.MessengerAPI.DAL.Repositories;
using StillMeBackend.MessengerAPI.DTO;

namespace StillMeBackend.MessengerAPI.Services;

public class ChatMemberService: ServiceBase<ChatMember, ChatMemberDto>
{
    public ChatMemberService(IRepository<ChatMember> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}