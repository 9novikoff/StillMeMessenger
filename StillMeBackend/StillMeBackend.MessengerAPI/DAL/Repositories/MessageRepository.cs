namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public class MessageRepository: RepositoryBase<Message>
{
    public MessageRepository(MessengerDbContext context) : base(context)
    {
    }
}