using Microsoft.EntityFrameworkCore;

namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public class ChatRepository: RepositoryBase<Chat>
{
    public ChatRepository(MessengerDbContext context) : base(context)
    {
    }

    public IEnumerable<Chat> GetChatsByUserId(string id)
    {
        return _context.Set<ChatMember>().Where(c => c.UserId == id).Select(c => c.Chat);
    }
}