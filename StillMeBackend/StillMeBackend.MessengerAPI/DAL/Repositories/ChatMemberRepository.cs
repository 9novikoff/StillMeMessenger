namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public class ChatMemberRepository: RepositoryBase<ChatMember>
{
    public ChatMemberRepository(MessengerDbContext context) : base(context)
    {
    }
}