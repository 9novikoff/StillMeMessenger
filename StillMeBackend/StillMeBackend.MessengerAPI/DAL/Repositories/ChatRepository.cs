using Microsoft.EntityFrameworkCore;

namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public class ChatRepository: RepositoryBase<Chat>
{
    public ChatRepository(MessengerDbContext context) : base(context)
    {
    }
}